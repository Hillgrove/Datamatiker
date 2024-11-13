
using Protocol;

var receiver    = new Receiver();
var sender      = new Sender();


// Create
string messageA = "create|John Due|Fuglevænget 12, 2000 Frederiksberg|12345678";
string messageB = "create|John Doe|Birdroad 12, 2000 Frederiksberg|12345678";
sender.Send(messageA, receiver);
sender.Send(messageB, receiver);

// Read
string messageC = "read|0";
string messageD = "read|1";
sender.Send(messageC, receiver);
sender.Send(messageD, receiver);

// Update
string messageE = "update|0|Lars Hansen|Fuglevænget 12, 2860 Søborg|88-888-888";
sender.Send(messageE, receiver);

// Delete
string messageF = "delete|1";
sender.Send(messageF, receiver);