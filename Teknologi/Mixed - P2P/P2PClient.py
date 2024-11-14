# The “client” peer asks the centralized server for a list of files, or for a list of peers for a specific file. Then it connects to a “server” peer asking for the file.

# You decide if you want to ask the user for input, or if you want to hardcode the values the client sends to the server.

# The client should ask the server for a list of peers for a file (or first for the list of files if you implemented this), and then either the user or the application selects a peer from that list, and then establish a TCP connection to the peer, sending the command:
# GET <filename>
# Then the peer starts sending the file, which the client saves on their harddisk (you choose where, or if the client asks the user?)
