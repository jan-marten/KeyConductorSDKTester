using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using KeyConductorSDK.Classes.DigiConnect;

namespace KeyConductorSDKTester.DigiDevice
{
    internal partial class frmDigiDeviceConfigure : Form
    {
        private DigiMessage _device = null;

        private bool _orgIsDHCP = false;
        private IPAddress _orgIP = null;
        private IPAddress _orgNetmask = null;
        private IPAddress _orgGateway = null;

        internal void SetDevice(DigiMessage device)
        {
            _device = device;
        }

        internal bool IsDHCP { get { return optNetworkDHCP.Checked; } }

        internal IPAddress NewIPAddress
        {
            get
            {
                return IPAddress.Parse(txtIPAddress.Text.Trim());
            }
        }

        internal IPAddress NewNetmask
        {
            get
            {
                return IPAddress.Parse(txtNetmask.Text.Trim());
            }
        }

        internal IPAddress NewDefaultGateway
        {
            get
            {
                return IPAddress.Parse(txtGateway.Text.Trim());
            }
        }


        public frmDigiDeviceConfigure()
        {
            InitializeComponent();
        }

        private void frmDigiDeviceConfigure_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            if (_device == null)
            {
                lblDeviceValue.Text = "Invalid device";
                lblMacAddressValue.Text = "";
                txtIPAddress.Text = "";
                txtNetmask.Text = "";
                txtGateway.Text = "";

                optNetworkDHCP.Enabled = false;
                optNetworkStatic.Enabled = false;

            }
            else
            {
                lblDeviceValue.Text = _device.DeviceName;
                lblMacAddressValue.Text = BitConverter.ToString(_device.MacAddress).Replace("-", ":");

                _orgIsDHCP = _device.DHCPEnabled;

                if (_orgIsDHCP)
                {
                    optNetworkDHCP.Checked = true;
                }
                else
                {
                    optNetworkStatic.Checked = true;
                }

                try
                {
                    _orgIP = new IPAddress(_device.IPAddress);
                    txtIPAddress.Text = _orgIP.ToString();

                    _orgNetmask = new IPAddress(_device.Netmask);
                    txtNetmask.Text = _orgNetmask.ToString();

                    _orgGateway = new IPAddress(_device.IPGateway);
                    txtGateway.Text = _orgGateway.ToString();

                }
                catch (Exception)
                {

                }
            }
        }

        private void optNetwork_CheckedChanged(object sender, EventArgs e)
        {
            txtIPAddress.Enabled = optNetworkStatic.Checked;
            txtNetmask.Enabled = optNetworkStatic.Checked;
            txtGateway.Enabled = optNetworkStatic.Checked;
        }

        private bool HasChanged()
        {
            if (optNetworkDHCP.Checked)
            {
                if (_orgIsDHCP)
                {
                    // Already DHCP configured
                    return false;
                }
                else
                {
                    // Was Static, now DHCP
                    return true;
                }
            }
            else
            {
                // check if IP-address got changed
                if (_orgIsDHCP == true ||
                    txtIPAddress.Text.Trim() != _orgIP.ToString() ||
                    txtNetmask.Text.Trim() != _orgNetmask.ToString() ||
                    txtGateway.Text.Trim() != _orgGateway.ToString())
                {
                    // DHCP/IP/Netmask/Gateway changed
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool changed = this.HasChanged();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            if (changed) this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }
}
