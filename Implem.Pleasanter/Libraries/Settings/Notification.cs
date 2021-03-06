﻿using Implem.DefinitionAccessor;
using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.DataSources;
using Implem.Pleasanter.Libraries.DataTypes;
using Implem.Pleasanter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
namespace Implem.Pleasanter.Libraries.Settings
{
    [Serializable()]
    public class Notification
    {
        public Types Type;
        public string Prefix;
        public string Address;
        public List<string> MonitorChangesColumns;

        public enum Types : int
        {
            Mail = 1,
            Slack = 2
        }

        public Notification(
            Types type, string prefix, string address, List<string> monitorChangesColumns)
        {
            Type = type;
            Prefix = prefix;
            Address = address;
            MonitorChangesColumns = monitorChangesColumns;
            MonitorChangesColumns = monitorChangesColumns;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext streamingContext)
        {
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext streamingContext)
        {
        }

        public void Update(string prefix, string address, List<string> columns)
        {
            Prefix = prefix;
            Address = address;
            MonitorChangesColumns = columns;
        }

        public void Send(string title, string url, string body)
        {
            var from = MailAddressUtilities.From(withFullName: true);
            switch (Type)
            {
                case Types.Mail:
                    new OutgoingMailModel()
                    {
                        SiteSettings = SiteSettingsUtility.OutgoingMailsSiteSettings(),
                        Title = new Title(Prefix + title),
                        Body = "{0}\n{1}".Params(url, body),
                        From = new System.Net.Mail.MailAddress(
                            Mails.Addresses.BadAddress(from) == string.Empty
                                ? from
                                : Parameters.Mail.SupportFrom),
                        To = Address
                    }.Send();
                    break;
                case Types.Slack:
                    new Slack("*{0}{1}*\n{2}\n{3}".Params(Prefix, title, url, body), from)
                        .Send(Address);
                    break;
                default:
                    break;
            }
        }

        public IEnumerable<Column> MonitorChangesColumnCollection(SiteSettings ss)
        {
            return MonitorChangesColumns
                .Select(o => ss.GetColumn(o))
                .Where(o => o != null)
                .ToList();
        }
    }
}