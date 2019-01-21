using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using KeyConductorSDK;
using V3 = KeyConductorSDK.V3;


namespace KeyConductorSDKTester.Classes
{

    public class StateObject
    {
        // Client  socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 64 * 1024;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];

    }

    /// <summary>
    /// Async-TCP server for KeyConductor Lite
    /// </summary>
    public class KeyConductorServer
    {
        private StateObject _stateObject; // there should only be ONE

        private byte[] _receiveBuffer;

        private UInt32 _kcid;

        #region public events

        public event EventHandler<LogMessageEventArgs> OnLogMessage;

        /// <summary>
        /// Event is raised when data has been received. Usefull for debugging.
        /// </summary>
        public event EventHandler<RawDataEventArgs> OnRawDataReceived;

        /// <summary>
        /// Event raised when data has been send to KeyConductor. Usefull for debugging.
        /// </summary>
        public event EventHandler<RawDataEventArgs> OnRawDataSend;


        /// <summary>
        /// Raw message from KeyConductor in MsgPack format
        /// </summary>
        public event EventHandler<KeyConductorRawCommandEventArgs> OnMessage;

        // on events

        /// <summary>Remote authentication request</summary>
        /// <remarks>Must be followed by a <see cref="AuthenticateRemoteUser(bool, short, short, string, bool, List{byte}, string, byte)"/> or else a timeout will occur after 10-20 seconds.</remarks>
        public event EventHandler<RemoteAuthenticationEventArgs> OnRemoteAuthentication;


        // On Event StandAlone

        /// <summary>
        /// User succesfully logged on to KeyConductor
        /// </summary>
        /// <remarks>Standalone only</remarks>
        public event EventHandler<OnEventUserEventArgs> OnEventLogin;

        /// <summary>
        /// User logged out from KeyConductor
        /// </summary>
        /// <remarks>Standalone only</remarks>
        public event EventHandler<OnEventUserEventArgs> OnEventLogout;

        /// <summary>
        /// Door was opened
        /// </summary>
        /// <remarks>Standalone only</remarks>
        public event EventHandler<OnEventDoorEventArgs> OnEventDoorOpen;
        /// <summary>
        /// Door was closed
        /// </summary>
        /// <remarks>Standalone only</remarks>
        public event EventHandler<OnEventDoorEventArgs> OnEventDoorClosed;

        /// <summary>
        /// KeyCop returned event
        /// </summary>
        /// <remarks>Standalone only</remarks>
        public event EventHandler<OnEventKeyEventArgs> OnEventKeyReturned;

        /// <summary>
        /// KeyCop picked event
        /// </summary>
        /// <remarks>Standalone only</remarks>
        public event EventHandler<OnEventKeyEventArgs> OnEventKeyPicked;

        /// <summary>
        /// Timeout event
        /// </summary>
        /// <remarks>Standalone only</remarks>
        public event EventHandler<OnEventWarningEventArgs> OnEventTimeout;

        /// <summary>
        /// Warning event
        /// </summary>
        /// <remarks>Standalone only</remarks>
        public event EventHandler<OnEventWarningEventArgs> OnEventWarning;

        /// <summary>
        /// External alarm
        /// </summary>
        /// <remarks>Standalone v3 only</remarks>
        public event EventHandler<OnEventWarningEventArgs> OnEventAlarm;

        /// <summary>
        /// External alarm cleared
        /// </summary>
        /// <remarks>Standalone v3 only</remarks>
        public event EventHandler<OnEventWarningEventArgs> OnEventAlarmCleared;

        /// <summary>
        /// Startup event
        /// </summary>
        /// <remarks>Standalone v3 only</remarks>
        public event EventHandler<OnEventWarningEventArgs> OnEventStartUp;

        // command replies

        /// <summary>Generic Command reply</summary>
        public event EventHandler<KeyConductorBaseReplyEventArgs> OnCommand;

        /// <summary>Put file result received</summary>
        public event EventHandler<KeyConductorBaseReplyEventArgs> OnPutFile;

        /// <summary>
        /// Set date/time result received
        /// </summary>
        /// <remarks>Works with standalone only</remarks>
        public event EventHandler<KeyConductorBaseReplyEventArgs> OnSetDateTime;

        /// <summary>Remote release reply received (use standalone fw 2.15rc2)</summary>
        public event EventHandler<KeyConductorBaseReplyEventArgs> OnRemoteRelease;

        /// <summary>Remote return reply received (use standalone fw 3)</summary>
        public event EventHandler<KeyConductorBaseReplyEventArgs> OnRemoteReturn;

        /// <summary>Remote reboot reply received (use standalone fw 3)</summary>
        public event EventHandler<KeyConductorBaseReplyEventArgs> OnRemoteReboot;

        /// <summary>Unknown command type reply received</summary>
        public event EventHandler<KeyConductorBaseReplyEventArgs> OnUnknownCommand;

        /// <summary>Get File command reply</summary>
        public event EventHandler<GetFileEventArgs> OnGetFile;

        /// <summary>Get File command reply</summary>
        public event EventHandler<GetFileProgressEventArgs> OnGetFileProgress;

        /// <summary>Get LifeView command reply</summary>
        /// <remarks>Works with standalone firmware v3 only</remarks>
        public event EventHandler<V3.LiveViewEventArgs> OnGetLiveView3;

        /// <summary>Get Info command reply</summary>
        public event EventHandler<GetInfoEventArgs> OnGetInfo;

        /// <summary>
        /// Mains voltage lost event (fw 3.3.2)
        /// </summary>
        /// <remarks>This option is only available when using a backup battery with emergency detection on Input 3</remarks>
        public event EventHandler<OnEventWarningEventArgs> OnEventMainsVoltageLost;

        /// <summary>
        /// Mains voltage connected event (fw 3.3.2)
        /// </summary>
        /// <remarks>This option is only available when using a backup battery with emergency detection on Input 3</remarks>
        public event EventHandler<OnEventWarningEventArgs> OnEventMainsVoltageConnected;

        #endregion

        public KeyConductorServer()
        {

        }

        public void StartListening(int port, UInt32 kcid)
        {
            _kcid = kcid;

            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];
            _receiveBuffer = new byte[] { };

            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, port);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(1);

                // Start an asynchronous socket to listen for connections.  
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(
                    new AsyncCallback(AcceptCallback),
                    listener);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            //StateObject state = new StateObject();
            _stateObject = new StateObject();

            _stateObject.workSocket = handler;
            handler.BeginReceive(_stateObject.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), _stateObject);
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.
                Array.Resize(ref _receiveBuffer, _receiveBuffer.Length + bytesRead);
                Array.Copy(state.buffer, 0, _receiveBuffer, _receiveBuffer.Length - bytesRead, bytesRead);

                //if (OnRawDataReceived != null)
                //{
                //    byte[] tmpBuffer = new byte[bytesRead];
                //    Array.Copy(state.buffer, 0, tmpBuffer, 0, bytesRead);
                //    //OnRawDataReceived(tmpBuffer); // note, do not send _receiveBuffer; too much data -> slow
                //    OnRawDataReceived?.Invoke(this, new RawDataEventArgs(tmpBuffer));
                //}

                HandleReceiveBuffer2(handler);

                // Get the rest of the data.
                state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

            }
        }

        private void Send(byte[] data)
        {
            if (_stateObject == null || _stateObject.workSocket == null) return;

            // Begin sending the data to the remote device.  
            _stateObject.workSocket.BeginSend(data, 0, data.Length, 0,
                new AsyncCallback(SendCallback), _stateObject);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                //Socket handler = (Socket)ar.AsyncState;

                StateObject stateObject = (StateObject)ar.AsyncState;
                var bytesSent = stateObject.workSocket.EndSend(ar);

                //// Complete sending the data to the remote device.  
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



        private void HandleReceiveBuffer2(Socket socket)
        {
            // TODO - Refactor HandleReceiveBuffer2

            // 1: best-case scenario: er staat een geheel bericht in buffer
            // 2: meerdere berichten in buffer
            // 3: deelbericht in buffer
            // 4: kapotte buffer

            //System.Diagnostics.Debug.Print(DateTime.Now.ToString("HH:mm:ss.fffff") + ":HandleReceiveBuffer2:" + _receiveBuffer.Length);

            var msgs = Protocol.ParseBuffer(ref _receiveBuffer);

            if (msgs == null)
            {
                return;
            }



            foreach (MsgPack.MessagePackObject msg in msgs)
            {

                //if (OnMessage != null)
                //{
                //    OnMessage(this, new KeyConductorRawCommandEventArgs(msg)); // this is the raw message from the KeyConductorLite
                //}

                // handle the message
                // first key/pair = KCID
                // second key/pair = CommandType
                // rest is based on commandtype

                var dicMessage = msg.AsDictionary();

                // Generic parameters
                string kcid = "000000000000"; // default kcid
                Protocol.CommandType commandType = Protocol.CommandType.Undefined;
                Protocol.ReturnValues returnValue = Protocol.ReturnValues.Undefined;
                string paramData = "";

                // Specific parameters
                byte position = 0;
                //Protocol.Capabilities capabilities = Protocol.Capabilities.None;
                Protocol.EventType eventType = Protocol.EventType.Undefined;

                Protocol.FileName fileName = Protocol.FileName.Undefined;
                uint fileChecksum = 0;
                byte[] fileContents = new byte[] { };

                foreach (var dc in dicMessage)
                {
                    if ((byte)dc.Key == (byte)Protocol.Parameter.KCID) // always first parameter
                    {
                        kcid = Convert.ToString((UInt32)dc.Value, 16);
                    }
                    else if ((byte)dc.Key == (byte)Protocol.Parameter.CommandType) // always second parameter
                    {
                        commandType = (Protocol.CommandType)(byte)dc.Value;

                        switch (commandType)
                        {
                            case Protocol.CommandType.GetInfo:
                                OnLogMessage?.Invoke(this, new LogMessageEventArgs("GetInfo request"));
                                ReturnInfo();
                                break;
                            case Protocol.CommandType.PutFile: 
                            case Protocol.CommandType.RemoteRelease:
                            case Protocol.CommandType.SetDateTime:
                            case Protocol.CommandType.RemoteReturn:
                                OnLogMessage?.Invoke(this, new LogMessageEventArgs(string.Format("Command:{0} request", commandType)));
                                ReturnOk(commandType);
                                break;
                        }

                    }
                    else if ((byte)dc.Key == (byte)Protocol.Parameter.Position)
                    {
                        position = (byte)dc.Value;
                    }
                    else // rest of the parameters depends on type of command/event
                    {
                        switch (commandType)
                        {
                            case Protocol.CommandType.GetFile:
                                {
                                    if ((byte)dc.Key == (byte)Protocol.Parameter.FileName)
                                    {
                                        fileName = (Protocol.FileName)(byte)dc.Value;

                                        OnLogMessage?.Invoke(this, new LogMessageEventArgs(string.Format("Command:GetFile {0} request", fileName)));
                                        ReturnDummyFile(fileName);

                                    }
                                }
                                break;


                            case Protocol.CommandType.OnEvent:
                                {
                                    if ((byte)dc.Key == (byte)Protocol.Parameter.EventType)
                                    {
                                        eventType = (Protocol.EventType)(byte)dc.Value;
                                    }

                                    else if ((byte)dc.Key == (byte)Protocol.Parameter.EventData)
                                    {
                                        // depends on eventType
                                        switch (eventType)
                                        {

                                            // Standalone events:

                                            case Protocol.EventType.RemoteAuthentication:
                                                {
                                                    //case Protocol.EventType.KeyBoardPress: // ter simulatie

                                                    string userCode = "0000";
                                                    string pinCode = "0000";
                                                    string userData = "";

                                                    // bytes[0] + bytes[1]: userCode of pinCode
                                                    // bytes[2] + bytes[3]: pinCode
                                                    // bytes[rest]: userData (optional)
                                                    paramData = BitConverter.ToString((byte[])dc.Value).Replace("-", "");

                                                    // Note that both UserCode and Pincode are byte-rotated; 1234 -> 3412

                                                    if (paramData.Length == 4)
                                                    {
                                                        pinCode = paramData.Substring(2, 2) + paramData.Substring(0, 2);
                                                    }
                                                    else if (paramData.Length >= 8)
                                                    {
                                                        userCode = paramData.Substring(2, 2) + paramData.Substring(0, 2);
                                                        pinCode = paramData.Substring(6, 2) + paramData.Substring(4, 2);
                                                    }

                                                    if (paramData.Length > 8)
                                                    {
                                                        for (int i = 8; i < paramData.Length; i++)
                                                        {
                                                            userData += (char)paramData[i]; // Convert.ToString(paramData[i], 10);
                                                        }
                                                    }

                                                    var evtArg = new RemoteAuthenticationEventArgs(kcid, userCode, pinCode, userData);
                                                    OnRemoteAuthentication?.Invoke(this, evtArg);
                                                }
                                                break;

                                            case Protocol.EventType.Login:
                                            case Protocol.EventType.Logout:
                                                {
                                                    string userCode = "0000";
                                                    string pinCode = "0000";
                                                    string userData = "";

                                                    // bytes[0] + bytes[1]: userCode of pinCode
                                                    // bytes[2] + bytes[3]: pinCode
                                                    // bytes[rest]: userData (optional)

                                                    byte[] tmpAuthData = (byte[])dc.Value;


                                                    paramData = BitConverter.ToString(tmpAuthData).Replace("-", "");

                                                    // Note that both UserCode and Pincode are NOT byte-rotated


                                                    if (paramData.Length == 4)
                                                    {
                                                        pinCode = paramData.Substring(0, 4);
                                                    }
                                                    else if (paramData.Length >= 8)
                                                    {
                                                        userCode = paramData.Substring(0, 4);
                                                        pinCode = paramData.Substring(4, 4);
                                                    }

                                                    if (paramData.Length > 8)
                                                    {
                                                        for (int i = 8; i < paramData.Length; i++)
                                                        {
                                                            userData += (char)paramData[i]; // Convert.ToString(paramData[i], 10);
                                                        }
                                                    }

                                                    var evtArg = new OnEventUserEventArgs(kcid, userCode, pinCode, userData);
                                                    if (eventType == Protocol.EventType.Login) OnEventLogin?.Invoke(this, evtArg);
                                                    else OnEventLogout?.Invoke(this, evtArg);

                                                }
                                                break;
                                            case Protocol.EventType.DoorOpen:
                                            case Protocol.EventType.DoorClosed:
                                                {

                                                    string userCode = "0000";

                                                    // bytes[0] + bytes[1]: userCode of pinCode

                                                    paramData = BitConverter.ToString((byte[])dc.Value).Replace("-", "");

                                                    // Note that both UserCode and Pincode are NOT byte-rotated

                                                    if (paramData.Length == 4)
                                                    {
                                                        userCode = paramData;
                                                    }

                                                    var evtArg = new OnEventDoorEventArgs(kcid, userCode, 0x00);
                                                    if (eventType == Protocol.EventType.DoorOpen) OnEventDoorOpen?.Invoke(this, evtArg);
                                                    else OnEventDoorClosed?.Invoke(this, evtArg);

                                                }
                                                break;
                                            case Protocol.EventType.KeyReturned:
                                            case Protocol.EventType.KeyPicked:
                                                {

                                                    string userCode = "0000";
                                                    ushort slot = 0;

                                                    // bytes[0] + bytes[1]: userCode
                                                    // V2: bytes[2]: slot
                                                    // V3: bytes[2] + bytes[3]: slot (ushort)

                                                    byte[] data = (byte[])dc.Value;
                                                    paramData = BitConverter.ToString(data).Replace("-", "");

                                                    // Note that both UserCode and Pincode are byte-rotated; 1234 -> 3412

                                                    userCode = paramData.Substring(2, 2) + paramData.Substring(0, 2);

                                                    if (data.Length == 3)
                                                    {
                                                        // Firmware 2
                                                        slot = data[2];
                                                    }
                                                    else if (data.Length == 4)
                                                    {
                                                        // Firmware 3
                                                        slot = (ushort)(data[2] * 256 + data[3]);
                                                    }

                                                    var evtArg = new OnEventKeyEventArgs(kcid, userCode, slot);
                                                    if (eventType == Protocol.EventType.KeyReturned) OnEventKeyReturned?.Invoke(this, evtArg);
                                                    else OnEventKeyPicked?.Invoke(this, evtArg);

                                                }
                                                break;
                                            case Protocol.EventType.Timeout:
                                            case Protocol.EventType.Warning:
                                            case Protocol.EventType.ExternalAlarm:
                                            case Protocol.EventType.ExternalAlarmCleared:
                                            case Protocol.EventType.Startup:
                                            case Protocol.EventType.MainsVoltageLost:
                                            case Protocol.EventType.MainsVoltageConnected:
                                                {
                                                    string userCode = "0000";

                                                    // bytes[0] + bytes[1]: userCode
                                                    byte[] data = (byte[])dc.Value;
                                                    paramData = BitConverter.ToString(data).Replace("-", "");

                                                    // Note that both UserCode is NOT byte-rotated
                                                    userCode = paramData;

                                                    var evtArg = new OnEventWarningEventArgs(kcid, userCode, eventType);

                                                    switch (eventType)
                                                    {
                                                        case Protocol.EventType.Warning:
                                                            OnEventWarning?.Invoke(this, evtArg);
                                                            break;
                                                        case Protocol.EventType.Timeout:
                                                            OnEventTimeout?.Invoke(this, evtArg);
                                                            break;
                                                        case Protocol.EventType.ExternalAlarm:
                                                            OnEventAlarm?.Invoke(this, evtArg);
                                                            break;
                                                        case Protocol.EventType.ExternalAlarmCleared:
                                                            OnEventAlarmCleared?.Invoke(this, evtArg);
                                                            break;
                                                        case Protocol.EventType.Startup:
                                                            OnEventStartUp?.Invoke(this, evtArg);
                                                            break;
                                                        case Protocol.EventType.MainsVoltageLost:
                                                            OnEventMainsVoltageLost?.Invoke(this, evtArg);
                                                            break;
                                                        case Protocol.EventType.MainsVoltageConnected:
                                                            OnEventMainsVoltageConnected?.Invoke(this, evtArg);
                                                            break;
                                                    }

                                                }
                                                break;
                                        }
                                    }
                                    else if ((byte)dc.Key == (byte)Protocol.Parameter.Result_Code) // n-th parameter
                                    {
                                        // dit komt niet voor bij events !!
                                    }
                                }
                                break;

                            default:
                                {
                                    if ((byte)dc.Key == (byte)Protocol.Parameter.Result_Code) // n-th parameter
                                    {
                                        returnValue = (Protocol.ReturnValues)(byte)dc.Value;

                                        var evtArg = new KeyConductorBaseReplyEventArgs(kcid, commandType, returnValue);

                                        OnCommand?.Invoke(this, evtArg);

                                        // raise event for individual functions
                                        switch (commandType)
                                        {
                                            case Protocol.CommandType.Unknown:
                                                OnUnknownCommand?.Invoke(this, evtArg);
                                                break;
                                            case Protocol.CommandType.PutFile:
                                                OnPutFile?.Invoke(this, evtArg);
                                                break;

                                            case Protocol.CommandType.SetDateTime:
                                                OnSetDateTime?.Invoke(this, evtArg);
                                                break;
                                            case Protocol.CommandType.RemoteRelease:
                                                OnRemoteRelease?.Invoke(this, evtArg);
                                                break;
                                            case Protocol.CommandType.RemoteReturn:
                                                OnRemoteReturn?.Invoke(this, evtArg);
                                                break;
                                            case Protocol.CommandType.RemoteReboot:
                                                OnRemoteReboot?.Invoke(this, evtArg);
                                                break;
                                        }

                                    } // if parameter = resultcode
                                }
                                break;
                        } // /Switch commandType
                    } //Else parameter
                } // foreach dc in dicMessage
            } // foreach msg in msgs
        } // /HandleReceiveBuffer


        public void SendDoorOpenEvent()
        {
            var data = ServerProtocol.BuildEvent(_kcid, Protocol.EventType.DoorOpen);
            Send(data);
        }
        internal void SendDoorClosedEvent()
        {
            var data = ServerProtocol.BuildEvent(_kcid, Protocol.EventType.DoorClosed);
            Send(data);
        }


        private void ReturnDummyFile(Protocol.FileName fileName)
        {
            var data = ServerProtocol.BuildGetFileReply(_kcid, new byte[] { }, fileName);
            Send(data);

        }

        private void ReturnInfo()
        {
            var data = ServerProtocol.BuildGetInfoReply(_kcid);
            Send(data);
        }

        private void ReturnOk( Protocol.CommandType commandType)
        {
            var data = ServerProtocol.BuildOkreply(_kcid, commandType);
            Send( data);
        }


        internal void SendLogin(string strUsercode, string strPincode, string swipecardData)
        {

            var data = ServerProtocol.BuildEventWithCredentialsMessage(_kcid, Protocol.EventType.RemoteAuthentication, BuildCredentials(strUsercode, strPincode, swipecardData));
            Send(data);

        }

        internal void SendLogout(string strUsercode, string strPincode, string swipecardData)
        {
            var data = ServerProtocol.BuildEventWithCredentialsMessage(_kcid, Protocol.EventType.Logout, BuildCredentials(strUsercode, strPincode, swipecardData));
            Send(data);
        }


        private string BuildCredentials(string strUsercode, string strPincode, string swipecardData)
        {
            string stringAuth = "";


            // Note that both UserCode and Pincode are byte-rotated; 1234 -> 3412

            if (strUsercode.Length == 0 && strPincode.Length > 0)
            {
                stringAuth += strPincode.Substring(2, 2);
                stringAuth += strPincode.Substring(0, 2);
                stringAuth += "0000";

            }
            else if (strUsercode.Length > 0 && strPincode.Length > 0)
            {
                stringAuth += strUsercode.Substring(2, 2);
                stringAuth += strUsercode.Substring(0, 2);
                stringAuth += strPincode.Substring(2, 2);
                stringAuth += strPincode.Substring(0, 2);
            }
            else
            {
                stringAuth = "00000000";
            }

            if (swipecardData.Length > 0)
            {
                stringAuth += swipecardData;
            }
            return stringAuth;
        }
    }

}
