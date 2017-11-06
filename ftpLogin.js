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

    uploadFiles();

    //writeToWebConfig('Web.config', process.env.SQL_DB_CONNECTION_STR);
    //clearRemoteDirectory();
}

function uploadFiles(c) {
    console.log('dirname: ' + __dirname);
    const files = finder.find(__dirname);

    console.log('listing files to copy over');

    files.forEach(function(file) {
        if (file.indexOf('.') != -1) {
            console.dir('uploading file: ' + file);

            c.put(file, file, function(err, b) {
                if (err) {
                    console.log('creating file error: ' + file);
                    //throw err;
                }

            });
        } else {
            console.dir('creating directory: ' + file);

            c.mkdir(file, function(err, b) {
                if (err) {
                    console.log('creating directory error: ' + file);
                    //throw err;
                }

            });
        }
    });

    console.log('done listing files to copy over');

    // c.on('ready', function() {
    //     console.log('starting upload');
    //
    //     c.list(function(err, list) {
    //         if (err) throw err;
    //
    //         list.forEach(function(file){
    //             console.dir(file.name);
    //             filesToDelete.push(file.name);
    //         });
    //
    //         console.log('done listing');
    //         console.log('starting to delete');
    //
    //         filesToDelete.forEach(function(entry) {
    //             if (entry.indexOf('.') != -1) {
    //                 console.dir('deleting file: ' + entry);
    //
    //                 c.delete(entry, function(err, b) {
    //                     if (err) {
    //                         console.log('deleting file error: ' + entry);
    //                         //throw err;
    //                     }
    //                 });
    //             } else {
    //                 console.dir('deleting directory: ' + entry);
    //
    //                 c.rmdir(entry, true, function(err, b) {
    //                     console.log('deleting directory error: ' + entry);
    //                     //throw err;
    //
    //                 });
    //             }
    //         });
    //
    //         c.end();
    //     });
    // });
    //
    // c.connect(setOptions());
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

            filesToDelete.forEach(function(entry) {
                if (entry.indexOf('.') != -1) {
                    console.dir('deleting file: ' + entry);

                    c.delete(entry, function(err, b) {
                        if (err) {
                            console.log('deleting file error: ' + entry);
                            //throw err;
                        }
                    });
                } else {
                    console.dir('deleting directory: ' + entry);

                    c.rmdir(entry, true, function(err, b) {
                        console.log('deleting directory error: ' + entry);
                        //throw err;

                    });
                }
            });

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

        newWebConfig.push(line);
    }

    fs.writeFileSync("./Web.config", newWebConfig);
}

runLogin();
