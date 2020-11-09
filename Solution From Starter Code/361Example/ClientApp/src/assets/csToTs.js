function TestFunction(email) {
  return "Hello " + email.toString();
} 

function ConnectToDB() {
  var http = require('http');

  module.exports = function (context) {
    context.log('JavaScript HTTP trigger function processed a request.');

    var options = {
      host: 'group4database.database.windows.net',
      port: '80',
      path: '/compile',
      method: 'POST'
    };

    // Set up the request
    var req = http.request(options, (res) => {
      var body = "";

      res.on("data", (chunk) => {
        body += chunk;
      });

      res.on("end", () => {
        context.res = body;
        context.done();
      });
    }).on("error", (error) => {
      context.log('error');
      context.res = {
        status: 500,
        body: error
      };
      context.done();
    });
    req.end();
  };
}

