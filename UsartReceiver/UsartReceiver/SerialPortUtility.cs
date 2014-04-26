using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Management;
using System.Data;
using System.Text.RegularExpressions;

namespace UsartReceiver
{
    static class SerialPortUtility
    {
        /// <summary>
        /// WMI を用いて COM ポート一覧を取得します。
        /// USB COM ポートは取得できませんが、仮想 COM ポートは取得できます。
        /// </summary>
        /// <returns></returns>
        ///
        private static Dictionary<string, string> GetSerialPortsFromWMISerialPort()
        {
            var mcW32SerialPort = new ManagementClass("Win32_SerialPort");
            var serialPorts = new Dictionary<string, string>();
          
            foreach (var serialPort in mcW32SerialPort.GetInstances())
            {
                var deviceId = serialPort.GetPropertyValue("DeviceID") as string;
                var caption = serialPort.GetPropertyValue("Caption") as string;

                // 値が取得できた場合
                if (deviceId != null && caption != null)
                {
                    serialPorts[deviceId] = caption;
                }   
            }

            return serialPorts;
        }

        /// <summary>
        /// WMI を用いて COM ポート一覧を取得します。
        /// USB COM ポートを取得できますが、仮想 COM ポートは取得できません。
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetSerialPortsFromWMIPnPEntity()
        {
            var mcW32PnPEntity = new ManagementClass("Win32_PnPEntity");
            var serialPorts = new Dictionary<string, string>();
            var regex = new Regex(@"\((COM\d+)\)");

            // すべての PnP エンティティに対して繰り返す
            foreach (var entity in mcW32PnPEntity.GetInstances())
            {
                // PnP エンティティの名前を取得する
                var name = entity.GetPropertyValue("Name") as string;

                // 名前が取得できた場合
                if (name != null)
                {
                    // 名前が COM ポートであるかマッチングを試みる
                    var match = regex.Match(name);

                    // COM ポートである場合
                    if(match.Success){
                        // マッチングした部分 (COM数字) をデバイス ID とする
                        var deviceId = match.Groups[1].Value;

                        // COM ポート一覧に追加
                        serialPorts[deviceId] = name;
                    }
                }

            }

            return serialPorts;
        }

        /// <summary>
        /// シリアルポートの一覧を取得する
        /// </summary>
        /// <returns>シリアルポートの一覧を表す連想配列。DeviceID をキーとして、説明を値とする。</returns>
        public static Dictionary<string,string> GetSerialPorts()
        {
            // Win32_SerialPort と Win32_PnPEntity で COM ポートを取得する
            var serialPortsFromWMISerialPort = SerialPortUtility.GetSerialPortsFromWMISerialPort();
            var serialPortsFromWMIPnPEntity = SerialPortUtility.GetSerialPortsFromWMIPnPEntity();

            // 結果をマージし、ひとつの連想配列にまとめる
            foreach (var serialPort in serialPortsFromWMIPnPEntity)
            {
                serialPortsFromWMISerialPort[serialPort.Key] = serialPort.Value;
            }

            // マージ結果を連想配列で返す
            return serialPortsFromWMISerialPort;
        }

        /// <summary>
        /// シリアルポートの一覧をデータテーブルで取得する
        /// </summary>
        /// <returns>
        /// シリアルポートの一覧を表すデータテーブル。
        /// デバイスの識別子 (COM数字) を表す DeviceID カラムと、
        /// デバイスの詳細を表す Caption カラムが存在する。
        /// </returns>
        public static DataTable GetSerialPortsAsDataTable()
        {
            // データテーブルを生成する
            var portsDataTable = new DataTable();

            portsDataTable.Columns.Add("DeviceID", typeof(string));
            portsDataTable.Columns.Add("Caption", typeof(string));

            // ポート一覧を取得する
            var portsDictionary = SerialPortUtility.GetSerialPorts();

            // Dictionary からデータテーブルへ変換する
            foreach (var deviceId in portsDictionary.Keys)
            {
                var row = portsDataTable.NewRow();

                row["DeviceID"] = deviceId;
                row["Caption"] = portsDictionary[deviceId];

                portsDataTable.Rows.Add(row);
            }

            return portsDataTable;
        }

    }
}
