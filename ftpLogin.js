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

    writeToWebConfig('Web.config', '');

    // var options = setOptions();
    // console.log('options: ', options);
    //
    // var c = new Client();
    //
    // c.on('ready', function() {
    //     c.list(function(err, list) {
    //         if (err) throw err;
    //         list.forEach(function(file){
    //             console.dir(file.name);
    //         });
    //         c.end();
    //     });
    // });
    //
    // c.connect(options);
}

function writeToWebConfig(file, entry) {
    const fileContents = fs.readFileSync(file, 'utf8');
    const lines = fileContents.split('\n');
    const newWebConfig = [];
    const dbString = process.env.SQL_DB_CONNECTION_STR;

    for (var i=0; i<lines.length; i++) {
        var line = lines[i];

        if (line.indexOf('BucketListDbConnStrProd') != -1) {
            line = '<add key="BucketListDbConnStrProd" value="' + dbString + '"/>';
        }

        newWebConfig.push(line);
    }

    fs.writeFileSync("./Web.config", newWebConfig);
}

runLogin();
