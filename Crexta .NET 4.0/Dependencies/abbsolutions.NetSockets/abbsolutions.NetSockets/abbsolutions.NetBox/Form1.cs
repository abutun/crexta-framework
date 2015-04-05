using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using abbSolutions.NetSockets;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace NetBox
{
    public partial class Form1 : Form
    {
        NetObjectServer server = new NetObjectServer();
        NetObjectClient client = new NetObjectClient();

        public Form1()
        {
            InitializeComponent();
            cbAddresses.DataSource = server.LocalAddresses;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!server.IsOnline)
            {
                //Set the deefault echo mode for everything that is received by the server.
                server.EchoMode = NetEchoMode.EchoAll;

                //Attach event handlers
                server.OnClientAccepted += new NetClientAcceptedEventHandler(server_OnClientAccepted);
                server.OnClientConnected += new NetClientConnectedEventHandler(server_OnClientConnected);
                server.OnClientDisconnected += new NetClientDisconnectedEventHandler(server_OnClientDisconnected);
                server.OnClientRejected += new NetClientRejectedEventHandler(server_OnClientRejected);
                server.OnReceived += new NetClientReceivedEventHandler<NetObject>(server_OnReceived);
                server.OnStarted += new NetStartedEventHandler(server_OnStarted);
                server.OnStopped += new NetStoppedEventHandler(server_OnStopped);

                //Start the server
                server.Start((IPAddress)cbAddresses.SelectedItem, 5432);

                //Attach event handlers
                client.OnDisconnected += new NetDisconnectedEventHandler(client_OnDisconnected);
                client.OnReceived += new NetReceivedEventHandler<NetObject>(client_OnReceived);
                client.OnConnected += new NetConnectedEventHandler(client_OnConnected);

                //Connect to the server
                client.TryConnect(((IPAddress)cbAddresses.SelectedItem).ToString(), 5432);
            }
        }

        void server_OnStopped(object sender, NetStoppedEventArgs e)
        {
            write("Server stopped");
        }
        void server_OnStarted(object sender, NetStartedEventArgs e)
        {
            write("Server started");
        }
        void server_OnReceived(object sender, NetClientReceivedEventArgs<NetObject> e)
        {
            /*The echo mode can be changed for this specific event...*/
            //e.EchoMode = NetEchoMode.EchoAllExceptSender;

            write("Server received");
        }
        void server_OnClientRejected(object sender, NetClientRejectedEventArgs e)
        {
            write("Client rejected by server, guid : " + e.Guid.ToString());
        }
        void server_OnClientDisconnected(object sender, NetClientDisconnectedEventArgs e)
        {
            write("Client disconnected from server, guid : " + e.Guid.ToString());
        }
        void server_OnClientConnected(object sender, NetClientConnectedEventArgs e)
        {
            /*The client can be rejected manually*/
            //e.Reject = true;

            write("Client connected to server, guid : " + e.Guid.ToString());
        }
        void server_OnClientAccepted(object sender, NetClientAcceptedEventArgs e)
        {
            write("Client accepted by server, guid : " + e.Guid.ToString());
        }

        void client_OnReceived(object sender, NetReceivedEventArgs<NetObject> e)
        {
            write("Client received");
        }
        void client_OnDisconnected(object sender, NetDisconnectedEventArgs e)
        {
            write("Client disconnected");
        }
        void client_OnConnected(object sender, NetConnectedEventArgs e)
        {
            write("Client connected");
        }
        
        void write(string s)
        {
            Invoke(new Action(delegate
            {
                textBox1.AppendText("[" + DateTime.Now.ToShortTimeString() + "] ");
                textBox1.AppendText(s + "\r\n");
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
                client.Send("abc", "abc");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.client.Disconnect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.server.DisconnectAll();

            server.Stop();
        }            
    }
}
