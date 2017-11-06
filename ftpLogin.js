var Client = require('ftp');
var fs = require('fs');

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

    writeToWebConfig('Web.config', process.env.SQL_DB_CONNECTION_STR);
    clearRemoteDirectory()

}

function uploadFiles() {
    const files = Finder.from(__dirname);

    console.log('listing files to copy over');

    files.forEach(function(file) {
        console.log(file);
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

            c.end();
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
