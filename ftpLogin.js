var Client = require('ftp');

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

    var options = setOptions();
    console.log('options: ', options);

    // var c = new Client();
    //
    // c.on('ready', function() {
    //     c.list(function(err, list) {
    //         if (err) throw err;
    //         console.dir(list);
    //         c.end();
    //     });
    // });
    //
    // c.connect(setOptions);
}

runLogin();
