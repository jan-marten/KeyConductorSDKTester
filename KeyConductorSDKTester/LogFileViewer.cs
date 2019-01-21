using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using KeyConductorSDK;

namespace KeyConductorSDKTester
{
    public partial class LogFileViewer : Form
    {
        public LogFileViewer()
        {
            InitializeComponent();
        }

        private void LogFileViewer_Load(object sender, EventArgs e)
        {
            string prevFilename = Properties.Settings.Default.PreviousLogFile;
            if (prevFilename.Length > 0)
            {
                if (File.Exists(prevFilename))
                {
                    txtFilename.Text = prevFilename;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();

            if (txtFilename.Text.Length > 0 && File.Exists(txtFilename.Text))
            {
                FileInfo fi = new FileInfo(txtFilename.Text);
                path = fi.Directory.FullName;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "KeyConductor files (KCL, V3)|*.kcl;*.v3|All files|*.*";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtFilename.Text = ofd.FileName;
                LoadLogFile();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadLogFile();
        }

        private void btnReloadLogKCL_Click(object sender, EventArgs e)
        {
            if (txtFilename.Text.ToUpper().EndsWith("KCL"))
            {

                LoadLogFileUsingKCL();
            }
            if (txtFilename.Text.ToUpper().EndsWith("V3"))
            {
                LoadLogFileUsingV3();
            }

        }


        private DataTable BuildTable()
        {
            var table = new DataTable("LOG");

            table.Columns.Add(new DataColumn("POS", typeof(string)));
            table.Columns.Add(new DataColumn("RAW", typeof(string)));
            table.Columns.Add(new DataColumn("HEX", typeof(string)));
            table.Columns.Add(new DataColumn("DT", typeof(string)));
            table.Columns.Add(new DataColumn("EVENT", typeof(string)));
            table.Columns.Add(new DataColumn("USER", typeof(string)));
            //table.Columns.Add(new DataColumn("PARAM", typeof(string)));
            table.Columns.Add(new DataColumn("REMARKS", typeof(string)));
            return table;
        }


        private void LoadLogFile()
        {
            var table = BuildTable();

            if (File.Exists(txtFilename.Text) == false)
            {

            }
            else
            {
                Properties.Settings.Default.PreviousLogFile = txtFilename.Text;
                Properties.Settings.Default.Save();

                var arrBytes = File.ReadAllBytes(txtFilename.Text);
                int rowNumber = 0;

                for (int offset = 0; offset < arrBytes.Length; offset = offset + 16)
                {
                    var objData = table.NewRow();


                    objData["POS"] = string.Format("{0}/{1}/0x{1:X}", rowNumber, offset); rowNumber++;
                    objData["RAW"] = ASCIIEncoding.UTF8.GetString(arrBytes, offset, 16);
                    objData["HEX"] = BitConverter.ToString(arrBytes, offset, 16);
                    objData["DT"] = "";
                    objData["EVENT"] = "";
                    objData["USER"] = "";
                    //objData["PARAM"] = "";
                    objData["REMARKS"] = "";



                    int unixTimeStamp;
                    byte[] barcode = new byte[6] { 0, 0, 0, 0, 0, 0 };
                    string strBarcode = "";
                    DateTime dtOldDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    DateTime dtNewDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    Int16 user_id = 0; // User.UserID
                    Int16 passw = 0;
                    string strMileage = "";

                    //logEntry.Message = "";
                    //logEntry.KeyCopID = 0;
                    //logEntry.UserID = 0;
                    //logEntry.KeyConductorID = _ID;
                    //logEntry.InternalIndex = internalIndex;

                    // get unixTimestamp
                    unixTimeStamp = BitConverter.ToInt32(arrBytes, offset);
                    if (unixTimeStamp > 0)
                    {
                        // unixTimestamp is based on UTC but set to localtime
                        objData["DT"] = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToString("s");
                    }

                    var eventType = (Protocol.EventTypeLog)arrBytes[offset + 4];
                    objData["EVENT"] = eventType.ToString();

                    // user-id is stored as 
                    user_id = (Int16)(arrBytes[offset + 6] * 256);
                    user_id += arrBytes[offset + 5];

                    // user_id is nu decimaal en dat moet nog naar hexadecimaal
                    if (!Int16.TryParse(Convert.ToString(user_id, 16), out user_id))
                    {
                        user_id = 0;
                    }

                    objData["USER"] = user_id.ToString("0000");

                    switch (eventType)
                    {
                        case Protocol.EventTypeLog.KeyReleased:
                        case Protocol.EventTypeLog.KeyReturned:
                        case Protocol.EventTypeLog.KeyUnknown:
                        case Protocol.EventTypeLog.KeyNotPicked:
                        case Protocol.EventTypeLog.KeyRemoved:
                        case Protocol.EventTypeLog.KeyRequestDenied:
                        case Protocol.EventTypeLog.RemoteRelease:
                        case Protocol.EventTypeLog.ReasonCodeEntered:
                        case Protocol.EventTypeLog.LockerReleased:
                        case Protocol.EventTypeLog.LockerOpened:
                        case Protocol.EventTypeLog.LockerClosed:
                        case Protocol.EventTypeLog.LockerAssetsRemoved:
                        case Protocol.EventTypeLog.LockerAssetsReturned:
                            Array.Copy(arrBytes, offset + 7, barcode, 0, 6);
                            strBarcode = BitConverter.ToString(barcode).Replace("-", "");
                            break;
                        case Protocol.EventTypeLog.LoginError:
                            passw = BitConverter.ToInt16(arrBytes, offset + 7);
                            break;
                        case Protocol.EventTypeLog.SetDateTime:
                            // oldDT:
                            unixTimeStamp = BitConverter.ToInt32(arrBytes, offset + 7);
                            dtOldDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeStamp);

                            // newDT
                            unixTimeStamp = BitConverter.ToInt32(arrBytes, offset + 11);
                            dtNewDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeStamp);

                            //logEntry.Message += dtOldDateTime.ToString("s") + "->" + dtNewDateTime.ToString("s");
                            objData["REMARKS"] += dtOldDateTime.ToString("s") + "->" + dtNewDateTime.ToString("s");
                            break;
                        case Protocol.EventTypeLog.InvalidLabel:
                            objData["REMARKS"] += "Label:" + BitConverter.ToInt16(arrBytes, offset + 7);
                            break;
                        case Protocol.EventTypeLog.MileageEntered:
                        case Protocol.EventTypeLog.MileageIncorrect:
                        case Protocol.EventTypeLog.MileageError:
                            Array.Copy(arrBytes, offset + 7, barcode, 0, 6);
                            strBarcode = BitConverter.ToString(barcode).Replace("-", "");
                            strMileage = BitConverter.ToString(arrBytes, offset + 13, 3).Replace("-", "");
                            break;

                    }


                    //// get user (database) ID
                    //if (user_id > 0)
                    //{
                    //    var user = (from u in dbCon.Users where u.UserID == user_id select u).FirstOrDefault();
                    //    if (user != null)
                    //    {
                    //        logEntry.UserID = user.ID;
                    //        logEntry.Message += string.Format("({0}) {1}", (int)user_id, user.Description);
                    //    }
                    //    else
                    //    {
                    //        logEntry.Message += string.Format("({0})", (int)user_id);
                    //    }
                    //}
                    //else
                    //{
                    //    // Unknown UserID, store in logfile
                    //    logEntry.Message += string.Format("Unknown user {0}", Convert.ToString(arrBytes[offset + 6], 16) + " " + Convert.ToString(arrBytes[offset + 5], 16));
                    //}


                    if (strBarcode != "")
                    {
                        //    // get keychain ID
                        //    var keyChain = (from kc in dbCon.KeyChains
                        //                    where kc.KeyNumber == strBarcode
                        //                    select kc).FirstOrDefault();
                        //    if (keyChain != null)
                        //    {
                        //        logEntry.KeyCopID = keyChain.ID;
                        //        logEntry.Message += string.Format("KeyCop {0} {1}", strBarcode, keyChain.KeyLabel);
                        //    }
                        //    else
                        //    {
                        objData["REMARKS"] += string.Format("KeyCop {0}", strBarcode);
                    }

                    if(strMileage.Length > 0)
                    {
                        objData["REMARKS"] += "Mileage:" + strMileage;

                    }


                    if (passw > 0)
                    {
                        objData["REMARKS"] += "PWD " + (int)passw + ",";
                    }

                    if (eventType == Protocol.EventTypeLog.RemoteRelease)
                    {
                        // reason-code given, firmware 2.16 RC1
                        byte reasonCode = arrBytes[offset + 7 + 6];
                        //var reason = Global.DBSettings.Get("RemoteReleaseReason" + reasonCode.ToString());
                        objData["REMARKS"] += string.Format(" Reason {0}", reasonCode);

                    }

                    //if (logEntry.DateTime > DateTime.Now.AddYears(-1) && logEntry.DateTime < DateTime.Now.AddHours(10))
                    //{

                    //    result.Add(logEntry);
                    //}
                    //else
                    //{
                    //    _logger.Warn("Log event too old or in the future:" + logEntry.DateTime.ToString() + " - " + logEntry.Message);

                    //}

                    table.Rows.Add(objData);

                }

            }

            BindingSource bs = new BindingSource();
            bs.Filter = string.Format("LEN('{0}') = 0 OR USER LIKE '%{0}%' OR REMARKS LIKE '%{0}%' OR EVENT LIKE '%{0}%'", txtFilter.Text);
            bs.DataSource = table;

            grdLog.DataSource = bs;
        }

        private void LoadLogFileUsingKCL()
        {
            var table = BuildTable();

            if (File.Exists(txtFilename.Text) == false)
            {

            }
            else
            {
                Properties.Settings.Default.PreviousLogFile = txtFilename.Text;
                Properties.Settings.Default.Save();

                var logFileData = new KeyConductorSDK.V2.LogDataCollection(txtFilename.Text);
                int rowNumber = 0;

                for (rowNumber = 0; rowNumber < logFileData.Count; rowNumber++)
                {
                    var objData = table.NewRow();

                    var rowData = logFileData[rowNumber];
                    var rowDataBytes = rowData.ToArray();

                    objData["POS"] = string.Format("{0}/{1}/0x{1:X}", rowNumber, rowNumber * 16);
                    objData["RAW"] = ASCIIEncoding.UTF8.GetString(rowDataBytes);
                    objData["HEX"] = BitConverter.ToString(rowDataBytes);
                    objData["DT"] = rowData.ToDateTime(rowData.Timestamp);
                    objData["EVENT"] = rowData.EventType.ToString();
                    objData["USER"] = rowData.UserID.ToString("0000");
                    //objData["PARAM"] = "";
                    objData["REMARKS"] = "";




                    switch (rowData.EventType)
                    {
                        case Protocol.EventTypeLog.KeyReleased:
                        case Protocol.EventTypeLog.KeyReturned:
                        case Protocol.EventTypeLog.KeyUnknown:
                        case Protocol.EventTypeLog.KeyNotPicked:
                        case Protocol.EventTypeLog.KeyRemoved:
                        case Protocol.EventTypeLog.KeyRequestDenied:
                        case Protocol.EventTypeLog.RemoteRelease:
                        case Protocol.EventTypeLog.ReasonCodeEntered:
                        case Protocol.EventTypeLog.LockerReleased:
                        case Protocol.EventTypeLog.LockerOpened:
                        case Protocol.EventTypeLog.LockerClosed:
                        case Protocol.EventTypeLog.LockerAssetsRemoved:
                        case Protocol.EventTypeLog.LockerAssetsReturned:
                            objData["REMARKS"] += string.Format("{0};{1};", rowData.Barcode, rowData.ReasonCode);
                            break;
                        case Protocol.EventTypeLog.LoginError:
                            objData["REMARKS"] += string.Format("{0};", rowData.Pincode);
                            break;
                        case Protocol.EventTypeLog.SetDateTime:
                            objData["REMARKS"] += string.Format("{0:s}->{1:s};", rowData.ToDateTime(rowData.TimestampOld), rowData.ToDateTime(rowData.TimestampNew));
                            break;
                    }

                    table.Rows.Add(objData);

                }

            }

            BindingSource bs = new BindingSource();
            bs.Filter = string.Format("LEN('{0}') = 0 OR USER LIKE '%{0}%' OR REMARKS LIKE '%{0}%'", txtFilter.Text);
            bs.DataSource = table;

            grdLog.DataSource = bs;
        }

        private void LoadLogFileUsingV3()
        {
            var table = BuildTable();

            if (File.Exists(txtFilename.Text) == false)
            {

            }
            else
            {
                Properties.Settings.Default.PreviousLogFile = txtFilename.Text;
                Properties.Settings.Default.Save();

                var logFileData = new KeyConductorSDK.V3.LogDataCollection(txtFilename.Text);
                int rowNumber = 0;

                for (rowNumber = 0; rowNumber < logFileData.Count; rowNumber++)
                {
                    var objData = table.NewRow();

                    var rowData = logFileData[rowNumber];
                    var rowDataBytes = rowData.ToArray();

                    objData["POS"] = string.Format("{0}/{1}/0x{1:X}", rowNumber, rowNumber * 16);
                    objData["RAW"] = ASCIIEncoding.UTF8.GetString(rowDataBytes);
                    objData["HEX"] = BitConverter.ToString(rowDataBytes);
                    objData["DT"] = rowData.ToDateTime(rowData.Timestamp);
                    objData["EVENT"] = rowData.EventType.ToString();
                    objData["USER"] = rowData.UserID.ToString("0000");
                    //objData["PARAM"] = "";
                    objData["REMARKS"] = "";




                    switch (rowData.EventType)
                    {
                        case Protocol.EventTypeLog.KeyReleased:
                        case Protocol.EventTypeLog.KeyReturned:
                        case Protocol.EventTypeLog.KeyUnknown:
                        case Protocol.EventTypeLog.KeyNotPicked:
                        case Protocol.EventTypeLog.KeyRemoved:
                        case Protocol.EventTypeLog.KeyRequestDenied:
                        case Protocol.EventTypeLog.RemoteRelease:
                        case Protocol.EventTypeLog.ReasonCodeEntered:
                        case Protocol.EventTypeLog.LockerReleased:
                        case Protocol.EventTypeLog.LockerAssetsRemoved:
                        case Protocol.EventTypeLog.LockerAssetsReturned:
                            objData["REMARKS"] += $"Barcode:{rowData.Barcode};Reason:{rowData.ReasonCode};Pos:{rowData.Position};";
                            break;
                        case Protocol.EventTypeLog.LockerOpened:
                        case Protocol.EventTypeLog.LockerClosed:
                            objData["REMARKS"] += $"Locker:{rowData.Position}";
                            break;
                        case Protocol.EventTypeLog.LoginError:
                            objData["REMARKS"] += $"Pincode:{rowData.Pincode}";
                            break;
                        case Protocol.EventTypeLog.SetDateTime:
                            objData["REMARKS"] += string.Format("{0:s}->{1:s};", rowData.ToDateTime(rowData.TimestampOld), rowData.ToDateTime(rowData.TimestampNew));
                            break;
                        case Protocol.EventTypeLog.InvalidLabel:
                            objData["REMARKS"] += "Label:" + rowData.InvalidLabel.ToString();
                            break;
                        case Protocol.EventTypeLog.MileageEntered:
                        case Protocol.EventTypeLog.MileageIncorrect:
                        case Protocol.EventTypeLog.MileageError:
                            objData["REMARKS"] += $"Barcode:{rowData.Barcode};Mileage:{rowData.MileageValue};";
                            break;

                    }

                    table.Rows.Add(objData);

                }

            }

            BindingSource bs = new BindingSource();
            bs.Filter = string.Format("LEN('{0}') = 0 OR USER LIKE '%{0}%' OR REMARKS LIKE '%{0}%'", txtFilter.Text);
            bs.DataSource = table;

            grdLog.DataSource = bs;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            //table.Columns.Add(new DataColumn("POS", typeof(string)));
            //table.Columns.Add(new DataColumn("RAW", typeof(string)));
            //table.Columns.Add(new DataColumn("HEX", typeof(string)));
            //table.Columns.Add(new DataColumn("DT", typeof(string)));
            //table.Columns.Add(new DataColumn("EVENT", typeof(string)));
            //table.Columns.Add(new DataColumn("USER", typeof(string)));
            ////table.Columns.Add(new DataColumn("PARAM", typeof(string)));
            //table.Columns.Add(new DataColumn("REMARKS", typeof(string)));
            if (grdLog.DataSource != null)
            {
                //DataView dv = ((BindingSource)(grdLog.DataSource)).def ds.Tables[0].DefaultView;
                //(grdLog.DataSource as DataTable).DefaultView.RowFilter = string.Format("LEN('{0}') = 0 OR USER LIKE '%{0}%' OR REMARKS LIKE '%{0}%'", txtFilter.Text);

                //dv.RowFilter = string.Format("country LIKE '%{0}%'", textBox1.Text);
                //dataGridView1.DataSource = dv;
            }
        }
    }
}
