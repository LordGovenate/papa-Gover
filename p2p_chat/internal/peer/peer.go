package peer

import (
    "bufio"
    "fmt"
    "net"
    "os"
)

var username string

//Los mensajes son leídos y enviados utilizando un bufio.Reader y un bufio.Writer, respectivamente. Los mensajes recibidos se imprimen en la consola, mientras que los mensajes enviados se leen desde la entrada estándar del usuario y se envían al peer conectado. La función handleConnection maneja las conexiones entrantes, permitiendo tanto recibir como enviar mensajes de manera simultánea.

func StartListening(port string, user string) {
    username = user
    listener, err := net.Listen("tcp", ":"+port)
    if err != nil {
        fmt.Println("Error listening:", err.Error())
        return
    }

    defer listener.Close()
    fmt.Printf("Peer is listening on port %v ...\n", port)
    for {
        conn, err := listener.Accept()
        if err != nil {
            fmt.Println("Error accepting connections:", err.Error())
            continue
        }
        go handleConnection(conn)
    }
}

func ConnectToPeer(address string, user string) {
    username = user
    conn, err := net.Dial("tcp", address)
    if err != nil {
        fmt.Println("Error connecting to peer:", err.Error())
        return
    }

    go receiveMessages(conn)
    sendMessages(conn)
}

func handleConnection(conn net.Conn) {
    go receiveMessages(conn)
    sendMessages(conn)
}

func receiveMessages(conn net.Conn) {
    defer conn.Close()
    reader := bufio.NewReader(conn)
    for {
        message, err := reader.ReadString('\n')
        if err != nil {
            fmt.Println("Error reading message:", err.Error())
            return
        }
        fmt.Print("Received: " + message)
    }
}

func sendMessages(conn net.Conn) {
    writer := bufio.NewWriter(conn)
    scanner := bufio.NewScanner(os.Stdin)
    for {
        fmt.Print("Type your message: ")
        if scanner.Scan() {
            message := scanner.Text() + "\n"
            _, err := writer.WriteString(username + ": " + message)
            if err != nil {
                fmt.Println("Error sending message:", err.Error())
                return
            }
            writer.Flush()
        }
        if scanner.Err() != nil {
            fmt.Println("Error reading input:", scanner.Err())
            return
        }
    }
}