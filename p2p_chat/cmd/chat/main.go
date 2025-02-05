package main

import (
	"os"

	"github.com/LordGovenate/p2p_chat/internal/peer"
)

//La función main() toma tres argumentos desde la línea de comando: la operación (connect o escuchar), la información de la conexión (dirección) y el nombre de usuario. Si la operación es "connect", el programa conecta al peer especificado; de lo contrario, pone al peer en modo de escucha para recibir conexiones entrantes.
func main(){
	
	operation := os.Args[1]
	connection := os.Args[2]
	username := os.Args[3]
	
	if operation == "connect" {
		peer.ConnectToPeer(connection, username)
	} else {
		peer.StartListening(connection, username)
	}

}