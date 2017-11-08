var https = require('https');

function verifyDeploy() {
    process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
    const url = 'https://www.tgimba.com';

    https.get(url, function(res) {
        if (res.statusCode === 200) {
            console.log('deployed site verified (url/code) (' + url + '/' + res.statusCode + ')');

        } else {
            throw new Error('Non 200 received after deploy - code: ' + res.statusCode);
        }
    }).on('error', function(e) {
        throw new Error('Deploy failed - Error: ' + e);
    });
}

verifyDeploy();