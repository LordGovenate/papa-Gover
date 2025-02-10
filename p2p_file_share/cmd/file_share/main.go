package main

import (
	"fmt"
	"os"

	"github.com/LordGovenate/p2p_file_share/internal/peer"
)

func main() {
	if len(os.Args) < 3 {
		fmt.Println("Insufficient arguments")
		return
	}

	done := make(chan struct{})
	go func() {
		defer close(done)
		peer.StartListening(os.Args[2]) 
	}()
	if os.Args[1] == "download" {
		if len(os.Args) < 6 {
			fmt.Println("Insufficient arguments for download")
			return
		}
		peer.DownloadFile(os.Args[3], os.Args[4], os.Args[5])
	} else {
		fmt.Println("Waiting for connections...") 
	}
	<-done
}