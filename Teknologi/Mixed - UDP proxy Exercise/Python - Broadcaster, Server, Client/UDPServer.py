from socket import AF_INET, SOCK_DGRAM, socket
import http.client

# Server parameters
SERVER_PORT = 10100
SERVERADDRESS = ("", SERVER_PORT)
serverSocket = socket(AF_INET, SOCK_DGRAM)

# API connection parameters
HOST = "localhost"
API_PORT = 5107
HEADERS = {
    "Content-Type": "application/json",
}

# Bind the socket to start listening for UDP broadcasts
serverSocket.bind(SERVERADDRESS)
print("The UDP server is ready")

while True:
    # Receive UDP broadcast data
    coded_sensor_data, clientAddress = serverSocket.recvfrom(2048)
    decoded_sensor_data = coded_sensor_data.decode()
    print("Received message:", decoded_sensor_data)

    # Send POST request to REST API
    conn = http.client.HTTPConnection(HOST, API_PORT)
    print("sending POST to API: " + decoded_sensor_data)
    conn.request(
        "POST",
        "/api/SensorData",
        body=decoded_sensor_data.encode("utf-8"),
        headers=HEADERS,
    )

    # Logging
    response = conn.getresponse()
    print("- Status code:", response.status)
    print("- Response data:", response.read().decode())
    print()
