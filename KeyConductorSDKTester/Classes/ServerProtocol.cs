using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyConductorSDK;
using MsgPack.Serialization.CollectionSerializers;
using System.IO;

namespace KeyConductorSDKTester.Classes
{
    class ServerProtocol
    {

        public static byte[] BuildOkreply(UInt32 kcid, Protocol.CommandType commandType)
        {
            // serialize to byte array for transmission via TCP/IP:
            MemoryStream ms = new MemoryStream();
            MsgPack.Packer packer = MsgPack.Packer.Create(ms);
            packer.PackMapHeader(3);

            //kcid, commandtype, OK

            // KCID
            packer.Pack((byte)Protocol.Parameter.KCID);
            packer.Pack((kcid));

            // Command ID
            packer.Pack((byte)Protocol.Parameter.CommandType);
            packer.Pack((byte)commandType);

            // KCResultCode
            packer.Pack((byte)Protocol.Parameter.Result_Code);
            packer.Pack((byte)Protocol.ReturnValues.OK);
          
            return ms.ToArray();

        }

        /// <summary>
        /// Build GetFileReply command
        /// </summary>
        /// <param name="kcid">KeyConductor ID</param>
        /// <param name="fileContents">Filecontents to send</param>
        /// <param name="kcFileName">Filename to put</param>
        /// <returns>Byte array which can be send to the KeyConductorSDK. See KeyConductorClient.Send(byte[])</returns>
        public static byte[] BuildGetFileReply(UInt32 kcid, byte[] fileContents, Protocol.FileName kcFileName)
        {
            // serialize to byte array for transmission via TCP/IP:
            MemoryStream ms = new MemoryStream();
            MsgPack.Packer packer = MsgPack.Packer.Create(ms);
            packer.PackMapHeader(5);

            //kcid, commandtype, filename, contents and checksum

            // KCID
            packer.Pack((byte)Protocol.Parameter.KCID);
            packer.Pack((kcid));

            // Command ID
            packer.Pack((byte)Protocol.Parameter.CommandType);
            packer.Pack((byte)Protocol.CommandType.GetFile);

            // filename
            packer.Pack((byte)Protocol.Parameter.FileName);
            packer.Pack((byte)kcFileName);

            // contents
            packer.Pack((byte)Protocol.Parameter.FileContent);
            packer.PackRaw(fileContents);

            // Add CRC32 (replaces FileLength which is included in raw-array anyway)
            var checkSum = KeyConductorSDK.CRC32.CountCrc(fileContents);
            packer.Pack((byte)Protocol.Parameter.FileChecksum);
#if DEBUG_PUTFILE_INVALIDCHECKSUM
            checkSum = (uint)(checkSum ^ 0xFF00FF00);
#endif
            packer.Pack(checkSum);



#if DEBUG_PUTFILE_BROKENUPLOAD
            // Firmware 3.1.0 testing broken upload system;
            var tmpArray = ms.ToArray();
            Array.Resize(ref tmpArray, tmpArray.Length - 10); // CHOP 10 bytes
            return tmpArray;
#else
            return ms.ToArray();
#endif

        }

        /// <summary>
        /// Build GetFileReply command
        /// </summary>
        /// <param name="kcid">KeyConductor ID</param>
        /// <returns>Byte array which can be send to the KeyConductorSDK. See KeyConductorClient.Send(byte[])</returns>
        public static byte[] BuildGetInfoReply(UInt32 kcid)
        {
            // serialize to byte array for transmission via TCP/IP:
            MemoryStream ms = new MemoryStream();
            MsgPack.Packer packer = MsgPack.Packer.Create(ms);
            packer.PackMapHeader(4);

            //kcid, commandtype, filename, contents and checksum

            // KCID
            packer.Pack((byte)Protocol.Parameter.KCID);
            packer.Pack((kcid));

            // Command ID
            packer.Pack((byte)Protocol.Parameter.CommandType);
            packer.Pack((byte)Protocol.CommandType.GetInfo);

            // KCResultCode
            packer.Pack((byte)Protocol.Parameter.Result_Code);
            packer.Pack((byte)Protocol.ReturnValues.OK);

            // info
            packer.Pack((byte)Protocol.Parameter.Info_Version);
            packer.PackRaw(Encoding.UTF8.GetBytes("Rev 3.0.0"));
           
            return ms.ToArray();

        }

        public static byte[] BuildEvent(UInt32 kcid, Protocol.EventType eventType)
        {
            // serialize to byte array for transmission via TCP/IP:
            MemoryStream ms = new MemoryStream();
            MsgPack.Packer packer = MsgPack.Packer.Create(ms);
            packer.PackMapHeader(4);

            //kcid, commandtype, filename, contents and checksum

            // KCID
            packer.Pack((byte)Protocol.Parameter.KCID);
            packer.Pack((kcid));

            // Command ID
            packer.Pack((byte)Protocol.Parameter.CommandType);
            packer.Pack((byte)Protocol.CommandType.OnEvent);

            // EvenType
            packer.Pack((byte)Protocol.Parameter.EventType);
            packer.Pack((byte)eventType);

            // EventData
            packer.Pack((byte)Protocol.Parameter.EventData);
            packer.PackRaw(new byte[] { 0, 1 });


            return ms.ToArray();
        }
        public static byte[] BuildEventWithCredentialsMessage(uint kcid, Protocol.EventType eventType, string stringAuth)
        {
            // serialize to byte array for transmission via TCP/IP:
            MemoryStream ms = new MemoryStream();
            MsgPack.Packer packer = MsgPack.Packer.Create(ms);
            packer.PackMapHeader(4);

            //kcid, commandtype, filename, contents and checksum

            // KCID
            packer.Pack((byte)Protocol.Parameter.KCID);
            packer.Pack((kcid));

            // Command ID
            packer.Pack((byte)Protocol.Parameter.CommandType);
            packer.Pack((byte)Protocol.CommandType.OnEvent);

            // EvenType
            packer.Pack((byte)Protocol.Parameter.EventType);
            packer.Pack((byte)eventType);

            // EventData
            packer.Pack((byte)Protocol.Parameter.EventData);
            // build data from stringAuth into bytes
            var eventData = KeyConductorSDK.Classes.Conversion.StringToByteArray(stringAuth);
            packer.PackRaw(eventData);

            return ms.ToArray();
        }

    }
}
