# SocketUdpCsharpForClients

<h1>Methods</h1>
<h4>Connect</h4>
<p>
The connect method has two parameters, the first is the server's IP and the second is the port.</p>

<h4>On</h4>
<p>
This method has two parameters, the port you want to hear the second one is a callBack function that brings the message.</p>
<strong>Example:</strong>
<code>
 socket.On("void", (string msg) =>
        {
            Console.Write(msg);
        });
</code>

<h4>Send</h4>
<p>
This method has two parameters, the first is the port and the second is the message you want to send to the server.</p>
<strong>Example:</strong>
<code>
 socket.Send("port", "Hello server");
</code>

<h4>Disconnected</h4>
<p>This method disconnects the user from the client and not directly from the server, as the UDP protocol does not connect. In order for you to disconnect from the server, you must send a message and configure this disconnection with the server. 
For better explanations use our SocketUDP Library in nodejs.</p>

<a href="https://github.com/jurniores/SocketUDP">https://github.com/jurniores/SocketUDP</a>
