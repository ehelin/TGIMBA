var Client = require('ftp');
var fs = require('fs');
var finder = require('fs-finder');

function setOptions() {
    var options = {
        host: process.env.FTP_HOST || 'localhost',
        port: 21,
        user: process.env.FTP_USER || 'anonymous',
        password: process.env.FTP_PASS || 'anonymous@'
    };

    return options;
}

function runLogin() {
    console.log('inside runLogin');

    console.log('writing to file');

    const webConfigFile = __dirname + '/Web.config';
    writeToWebConfig(webConfigFile, process.env.SQL_DB_CONNECTION_STR);
    //writeToWebConfig(webConfigFile, 'aDbString');
    clearRemoteDirectory();
}

function uploadFiles(c) {
    const parent = __dirname;

    console.log('parent: ' + parent);

    const files = finder.find(parent);

    if (c === undefined || c === null) {
        console.log('inside - uploadFiles - c is null');
    } else {
        console.log('inside - uploadFiles - c is not null');
    }

    console.log('copying files over');

    files.forEach(function(file) {
        console.log('file: ' + file);
        const toCreateFile = file.replace(parent, '');

        if (toCreateFile.indexOf('.') != -1) {
            console.dir('uploading file: ' + toCreateFile);

            c.put(file, toCreateFile, function(err, b) {
                if (err) {
                    console.log('creating file error: ' + toCreateFile);
                    //throw err;
                }
            });
        } else {
            console.dir('creating directory: ' + toCreateFile);

            c.mkdir(toCreateFile, function(err, b) {
                if (err) {
                    console.log('creating directory error: ' + toCreateFile);
                    //throw err;
                }
            });
        }
    });

    c.end();

    console.log('done copying files over');
}

function clearRemoteDirectory() {
    var filesToDelete = [];
    var c = new Client();

    c.on('ready', function() {
        console.log('starting list');

        c.list(function(err, list) {
            if (err) throw err;

            list.forEach(function(file){
                console.dir(file.name);
                filesToDelete.push(file.name);
            });

            console.log('done listing');
            console.log('starting to delete');

            // filesToDelete.forEach(function(entry) {
            //     if (entry.indexOf('.') != -1) {
            //         console.dir('deleting file: ' + entry);
            //
            //         c.delete(entry, function(err, b) {
            //             if (err) {
            //                 console.log('deleting file error: ' + entry);
            //                 //throw err;
            //             }
            //         });
            //     } else {
            //         console.dir('deleting directory: ' + entry);
            //
            //         c.rmdir(entry, true, function(err, b) {
            //             console.log('deleting directory error: ' + entry);
            //             //throw err;
            //
            //         });
            //     }
            // });

            // console.log('after filetodelete');
            //
            // if (c === undefined || c === null) {
            //     console.log('c is null');
            // } else {
            //     console.log('c is not null');
            // }

            uploadFiles(c);
        });
    });

    c.connect(setOptions());
}

function writeToWebConfig(file, entry) {
    const fileContents = fs.readFileSync(file, 'utf8');
    const lines = fileContents.split('\n');
    const newWebConfig = [];

    for (var i=0; i<lines.length; i++) {
        var line = lines[i];

        if (line.indexOf('BucketListDbConnStrProd') != -1) {
            line = '<add key="BucketListDbConnStrProd" value="' + entry + '"/>';
        }

        line = line.replace(',','');

        newWebConfig.push(line);
    }

    fs.writeFileSync("./Web.config", newWebConfig);
}

runLogin();
