using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyConductorSDK.Classes.DigiConnect;

namespace KeyConductorSDKTester.DigiDevice
{
    /// <summary>
    /// This form is used to discover Digi Connect ME modules with ADDP enabled.
    /// It is assumed that the keyconductor is in the same physical LAN inside the same IP-range.
    /// </summary>
    internal partial class frmDigiDeviceDiscovery : Form
    {
        DigiManager digiManager;

        private string _ip = "";
        public string IP { get { return _ip; } }

        public frmDigiDeviceDiscovery(string ip)
        {
            InitializeComponent();

            digiManager = new DigiManager();
            digiManager.DiscoveryResponse += DigiManager_DiscoveryResponse;
            digiManager.RebootResponse += DigiManager_RebootResponse;
            digiManager.StaticNetworkResponse += DigiManager_StaticNetworkResponse;
            digiManager.DHCPNetworkResponse += DigiManager_DHCPNetworkResponse;
            digiManager.DevicesFound += DigiManager_DevicesFound;

            _ip = ip;
        }





        private void DigiManager_DHCPNetworkResponse(object sender, DeviceMessageEventArgs e)
        {
            if (e.DigiMessage == null)
            {
                MessageBox.Show("Network timeout detected. Please try again.", "Timeout");
            }
            else if (e.DigiMessage.ResultFlag == ResultFlags.Succes)
            {
                // a reboot is required before settings are applied
                MessageBox.Show("A reboot is required before settings are applied.", "Reboot KeyConductor");
            }
            else
            {
                MessageBox.Show(string.Format("DHCP Configuration failed: {0}", e.DigiMessage.ResultMessage));
            }
        }

        private void DigiManager_StaticNetworkResponse(object sender, DeviceMessageEventArgs e)
        {
            if (e.DigiMessage == null)
            {
                MessageBox.Show("Network timeout detected. Please try again.", "Timeout");
            }
            else if (e.DigiMessage.ResultFlag == ResultFlags.Succes)
            {
                // a reboot is required before settings are applied
                MessageBox.Show("A reboot is required before settings are applied.", "Reboot KeyConductor");
            }
            else
            {
                MessageBox.Show(string.Format("Static-IP Configuration failed: {0}", e.DigiMessage.ResultMessage));
            }
        }

        private void DigiManager_RebootResponse(object sender, DeviceMessageEventArgs e)
        {
            if (e.DigiMessage == null)
            {
                MessageBox.Show("Network timeout detected. Please try again.", "Timeout");
            }
            else if (e.DigiMessage.ResultFlag == ResultFlags.Succes)
            {
                MessageBox.Show("Rebooting network interface.", "Rebooting");
            }
            else
            {
                MessageBox.Show(string.Format("Reboot failed: {0}", e.DigiMessage.ResultMessage));
            }
        }

        private void frmDigiDeviceDiscovery_Load(object sender, EventArgs e)
        {
            SearchDevices();
        }

        private void SearchDevices()
        {
            btnRefresh.Enabled = false;
            btnConfigure.Enabled = false;
            btnReboot.Enabled = false;
            btnWebConfig.Enabled = false;

            listView1.Items.Clear();
            digiManager.SearchDevices(2000);
        }

        private delegate void DigiManager_DevicesFoundDelegate(object sender, DevicesFoundEventArgs e);
        private void DigiManager_DevicesFound(object sender, DevicesFoundEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new DigiManager_DevicesFoundDelegate(DigiManager_DevicesFound), new object[] { sender, e });
                }
                else
                {
                    btnRefresh.Enabled = true;
                    btnConfigure.Enabled = true;
                    btnReboot.Enabled = true;
                    btnWebConfig.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private delegate void DigiManager_DiscoveryResponseDelegate(object sender, DeviceMessageEventArgs e);
        private void DigiManager_DiscoveryResponse(object sender, DeviceMessageEventArgs e)

        {
            try
            {
                if (e.DigiMessage == null) return;

                if (this.InvokeRequired)
                {
                    this.Invoke(new DigiManager_DiscoveryResponseDelegate(DigiManager_DiscoveryResponse), new object[] { sender, e });
                }
                else
                {
                    ListViewItem itm = new ListViewItem();
                    itm.Text = e.DigiMessage.ByteToIPAddress(e.DigiMessage.IPAddress).ToString();
                    itm.SubItems.Add(BitConverter.ToString(e.DigiMessage.MacAddress));
                    itm.SubItems.Add(e.DigiMessage.NetworkName);
                    itm.SubItems.Add(e.DigiMessage.DeviceName);
                    itm.Tag = e.DigiMessage;

                    if (itm.Text == _ip) itm.Selected = true;

                    listView1.Items.Add(itm);

                }
            }
            catch (Exception)
            {

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                _ip = listView1.SelectedItems[0].Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                _ip = listView1.SelectedItems[0].Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SearchDevices();
        }

        private void btnWebConfig_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                // get text = IP address
                string ip = listView1.SelectedItems[0].Text;
                string httpAddress = "http://" + ip;
                Help.ShowHelp(this, httpAddress);
            }
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            try
            {

                if (listView1.SelectedItems.Count == 1)
                {
                    DigiMessage device = (DigiMessage)listView1.SelectedItems[0].Tag;


                    frmDigiDeviceConfigure fConfig = new frmDigiDeviceConfigure();
                    fConfig.SetDevice(device);
                    var dlgRes = fConfig.ShowDialog(this);
                    if (dlgRes == System.Windows.Forms.DialogResult.OK)
                    {
                        // change settings

                        if (fConfig.IsDHCP)
                        {
                            digiManager.SetDHCP(device.MacAddress, 2000);
                        }
                        else
                        {
                            digiManager.SetStaticIP(
                                device.MacAddress,
                                fConfig.NewIPAddress,
                                fConfig.NewNetmask,
                                fConfig.NewDefaultGateway,
                                2000);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while configuring the device. Review configuration and try again.\n\n" + ex.Message, "Configuration error");
            }

        }

        private void btnReboot_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 1)
            {
                DigiMessage device = (DigiMessage)listView1.SelectedItems[0].Tag;

                digiManager.Reboot(device.MacAddress, 2000);

            }
        }

    }
}
