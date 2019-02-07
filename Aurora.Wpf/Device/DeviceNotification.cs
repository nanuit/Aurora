using System;
using System.Runtime.InteropServices;

namespace Aurora.Wpf.Device
{
    public static class DeviceNotification
    {
        public enum DBTDeviceType
        {
            DeviceInterface = 5,
            Handle = 6,
            Oem = 0,
            Port = 3,
            Volume = 2
        }

        public enum DBTEventType
        {
            Arrival = 0x8000,
            RemoveComplete = 0x8004,
            NodeChanged = 7,
            TypeSpecific = 0x8005
        }

        public enum DBTF
        {
            Media = 1,
            Net = 2
        }

        //https://msdn.microsoft.com/en-us/library/aa363480(v=vs.85).aspx
        
        
        public const int WmDevicechange = 0x0219; // device change event      
        
        
        //https://msdn.microsoft.com/en-us/library/aa363431(v=vs.85).aspx
        private const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;
        private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
        private static IntPtr m_NotificationHandle;

        /// <summary>
        /// Registers a window to receive notifications when devices are plugged or unplugged.
        /// </summary>
        /// <param name="windowHandle">Handle to the window receiving notifications.</param>
        /// <param name="usbOnly">true to filter to USB devices only, false to be notified for all devices.</param>
        public static void RegisterDeviceNotification(IntPtr windowHandle, bool usbOnly = false)
        {
            var dbi = new DEV_BROADCAST_DEVICEINTERFACE_FIXED()
            {
                Devicetype = (int)DBTDeviceType.DeviceInterface,
                Reserved = 0,
                Classguid = GuidDevinterfaceUSBDevice,
                Name = (char)0
            };
            
            dbi.Size = Marshal.SizeOf(dbi);
            IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
            Marshal.StructureToPtr(dbi, buffer, true);

            m_NotificationHandle = RegisterDeviceNotification(windowHandle, buffer, usbOnly ? 0 : DEVICE_NOTIFY_ALL_INTERFACE_CLASSES);
        }

        /// <summary>
        /// Unregisters the window for device notifications
        /// </summary>
        public static void UnregisterDeviceNotification()
        {
            UnregisterDeviceNotification(m_NotificationHandle);
        }

        public static DeviceData GetDevice(IntPtr lParam)
        {
            DeviceData itemData = new DeviceData();
            if ((int)lParam == 0)
                return itemData;
            
            DEV_BROADCAST_HDR hdr = new DEV_BROADCAST_HDR();
            Marshal.PtrToStructure(lParam, hdr);
            itemData.DeviceType = ((DBTDeviceType)hdr.dbch_devicetype);
            switch ((DBTDeviceType)hdr.dbch_devicetype)
            {
                case DBTDeviceType.DeviceInterface:
                    DEV_BROADCAST_DEVICEINTERFACE_VARIABLE devIF = new DEV_BROADCAST_DEVICEINTERFACE_VARIABLE();

                    // Convert lparam to DEV_BROADCAST_DEVICEINTERFACE structure
                    Marshal.PtrToStructure(lParam, devIF);

                    // Get the device path from the broadcast message
                    itemData.Data = new string(devIF.dbcc_name);

                    // Remove null-terminated data from the string
                    int pos = itemData.Data.IndexOf((char)0);
                    if (pos != -1)
                    {
                        itemData.Data = itemData.Data.Substring(0, pos);
                    }
                    break;
                case DBTDeviceType.Port:
                    DEV_BROADCAST_PORT_VARIABLE devPort = new DEV_BROADCAST_PORT_VARIABLE();

                    // Convert lparam to DEV_BROADCAST_DEVICEINTERFACE structure
                    Marshal.PtrToStructure(lParam, devPort);

                    // Get the device path from the broadcast message
                    itemData.Data = new string(devPort.dbcc_name);

                    // Remove null-terminated data from the string
                    pos = itemData.Data.IndexOf((char)0);
                    if (pos != -1)
                    {
                        itemData.Data = itemData.Data.Substring(0, pos);
                    }
                    break;
                case DBTDeviceType.Volume:
                    DEV_BROADCAST_VOLUME volume = new DEV_BROADCAST_VOLUME();
                    Marshal.PtrToStructure(lParam, volume);
                    itemData.Data = $"{((volume.dbcv_flags & (int) DBTF.Media) == 1 ? "Media" : "Net")} {FirstDriveFromMask(volume.dbcv_unitmask)}";
                    break;

                    
            }
            return (itemData);
        }

        public static char FirstDriveFromMask(int unitmask)
        {
            
            int i;

            for (i = 0; i < 26; ++i)
            {
                if ((unitmask & 0x1) == 1)
                    break;
                unitmask = unitmask >> 1;
            }

            return ((char)(i + 65));
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

        [DllImport("user32.dll")]
        private static extern bool UnregisterDeviceNotification(IntPtr handle);

        [StructLayout(LayoutKind.Sequential)]
        public class DEV_BROADCAST_DEVICEINTERFACE_FIXED
        {
            public int Size;
            public int Devicetype;
            public int Reserved;
            public Guid Classguid;
            public char Name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class DEV_BROADCAST_DEVICEINTERFACE_VARIABLE
        {
            public int dbcc_size;
            public int dbcc_devicetype;
            public int dbcc_reserved;
            public Guid dbcc_classguid;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
            public char[] dbcc_name;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class DEV_BROADCAST_HDR
        {
            public int dbch_size;
            public int dbch_devicetype;
            public int dbch_reserved;
        }
        [StructLayout(LayoutKind.Sequential)]
        public class DEV_BROADCAST_PORT_FIXED
        {
            public int dbcp_size;
            public int dbcp_devicetype;
            public int dbcp_reserved;
            public char dbcc_name;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class DEV_BROADCAST_PORT_VARIABLE
        {
            public int dbcp_size;
            public int dbcp_devicetype;
            public int dbcp_reserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
            public char[] dbcc_name;
        }
        [StructLayout(LayoutKind.Sequential)]
        public class DEV_BROADCAST_VOLUME
        {
            public int dbcv_size;
            public int dbcv_devicetype;
            public int dbcv_reserved;
            public int dbcv_unitmask;
            public char dbcv_flags;
        }
    }
}
