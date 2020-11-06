using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MinidumpExplorer.Utilities
{
    internal class UpdateChecker
    {
        public static string CheckForUpdates(string feedUrl)
        {
            try
            {
                Atom10FeedFormatter formatter = new Atom10FeedFormatter();

                XmlReaderSettings readerSettings = new XmlReaderSettings();
                readerSettings.DtdProcessing = DtdProcessing.Parse;

                using (XmlReader reader = XmlReader.Create(feedUrl, readerSettings))
                {
                    if (!formatter.CanRead(reader)) return null;

                    formatter.ReadFrom(reader);

                    var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                    var update = (from i in formatter.Feed.Items
                                  where new Version(i.Title.Text) > currentVersion
                                  orderby i.LastUpdatedTime descending
                                  select i).FirstOrDefault();

                    if (update != null)
                        return update.Links.Single().Uri.ToString();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("MinidumpExplorer: Update check failed: " + ex.ToString());

                return null;
            }
        }
    }
}
