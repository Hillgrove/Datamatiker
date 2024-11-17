from socket import AF_INET, SOCK_STREAM, socket, timeout

SERVER_NAME = "localhost"
PORT_RANGE = range(1, 65536)  # 16 bit

open_ports = []


for port in PORT_RANGE:
    try:
        with socket(AF_INET, SOCK_STREAM) as clientSocket:
            clientSocket.settimeout(0.5)
            clientSocket.connect((SERVER_NAME, port))
            open_ports.append(port)
            print(f"Port {port} open")
    except timeout:
        print(f"Port {port} closed (timeout)")
    except OSError:
        print(f"Port {port} closed (connection refused)")


print("\nAll open ports:")
for port in open_ports:
    print(f"  - {port}")
