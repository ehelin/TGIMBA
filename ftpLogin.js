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

    writeToWebConfig(__dirname + '/Web.config', process.env.SQL_DB_CONNECTION_STR);
    clearRemoteDirectory();
}

function uploadFiles(c) {
    console.log('inside uploadFiles');

    const parent = __dirname;
    const files = finder.find(parent);

    files.forEach(function(file) {
        const toCreateFile = file.replace(parent, '');

        if (toCreateFile.indexOf('.') != -1) {
            c.put(file, toCreateFile, function(err, b) {
                if (err) {
                    console.log('creating file error: ' + toCreateFile);
                }
            });
        } else {
            c.mkdir(toCreateFile, function(err, b) {
                if (err) {
                    console.log('creating directory error: ' + toCreateFile);
                }
            });
        }
    });

    c.end();
}

function clearRemoteDirectory() {
    var filesToDelete = [];
    var c = new Client();

    c.on('ready', function() {
        c.list(function(err, list) {
            if (err) throw err;

            list.forEach(function(file){
                console.dir(file.name);
                filesToDelete.push(file.name);
            });

            filesToDelete.forEach(function(entry) {
                if (entry.indexOf('.') != -1) {
                    c.delete(entry, function(err, b) {
                        if (err) {
                            console.log('deleting file error: ' + entry);
                        }
                    });
                } else {
                    c.rmdir(entry, true, function(err, b) {
                        if (err) {
                            console.log('deleting directory error: ' + entry);
                        }
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
    var newWebConfig = '';

    for (var i=0; i<lines.length; i++) {
        var line = lines[i];

        if (line.indexOf('BucketListDbConnStrProd') != -1) {
            line = '<add key="BucketListDbConnStrProd" value="' + entry + '"/>';
        }

        newWebConfig = newWebConfig + line;
    }

    fs.writeFileSync("./Web.config", newWebConfig);
}

runLogin();
