using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRV_3
{
    public partial class Form1 : Form
    {
        private NamedPipeServerStream pipeServer;
        private Process cmdProcess;
        public string serverMessage = "Standard message!";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            await RunPipeServerAsync();
        }

        private void runPrimary_Click(object sender, EventArgs e)
        {
            StartCmdProcess(inputPrimary.Text);
        }

        private void runSecondary_Click(object sender, EventArgs e)
        {
            serverMessage = inputSecondary.Text;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cleanup();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cleanup();
        }

        private void Cleanup()
        {
            if (cmdProcess != null && !cmdProcess.HasExited)
            {
                cmdProcess.Kill();
            }
            pipeServer?.Close();
        }

        private async Task RunPipeServerAsync()
        {
            pipeServer = new NamedPipeServerStream("testPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            Console.WriteLine("Waiting for client connection...");
            await pipeServer.WaitForConnectionAsync();
            Console.WriteLine("Client connected.");

            // Handle communication with the connected client in separate tasks
            _ = HandleClientReadingAsync(pipeServer);
            _ = HandleClientWritingAsync(pipeServer);
        }


        static async Task HandleClientReadingAsync(NamedPipeServerStream server)
        {
            using (StreamReader reader = new StreamReader(server, Encoding.UTF8))
            {
                while (server.IsConnected)
                {
                    string clientMessage = await reader.ReadLineAsync();
                    if (clientMessage != null)
                    {
                        // Console.WriteLine("Received from client: " + clientMessage);
                    }
                }
            }
        }

        async Task HandleClientWritingAsync(NamedPipeServerStream server)
        {
            using (StreamWriter writer = new StreamWriter(server, Encoding.UTF8) { AutoFlush = true })
            {
                while (server.IsConnected)
                {
                    await writer.WriteLineAsync(serverMessage);
                    // Console.WriteLine("Sent to client: " + serverMessage);

                    // Delay to simulate some processing or wait for a response
                    await Task.Delay(1000); // Отправляем сообщение каждую секунду
                }
            }
        }

        private void StartCmdProcess(string command)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            cmdProcess = new Process { StartInfo = startInfo };
            cmdProcess.OutputDataReceived += (s, e) => AppendOutput(e.Data);
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();

            if (pipeServer.IsConnected)
            {
                AppendOutput("Канал подключен к процессу.");
            }
        }

        private void AppendOutput(string text)
        {
            if (outputTextBox.InvokeRequired)
            {
                outputTextBox.Invoke(new Action<string>(AppendOutput), text);
            }
            else
            {
                outputTextBox.AppendText(text + Environment.NewLine);
            }
        }
    }
}
