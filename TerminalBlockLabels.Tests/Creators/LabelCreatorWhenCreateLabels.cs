using CleaverBrooks.Orders;
using CleaverBrooks.TerminalStripUtility.Library.Creators;
using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Creators
{
    /// <summary>
    /// Class for testing the <see cref="LabelCreator.CreateLabels"/> method.
    /// </summary>
    [TestClass]
    public class LabelCreatorWhenCreateLabels
    {
        [TestMethod]
        public void ShouldCreateCorrectLabels()
        {
            List<TerminalBlock> terminalBlocks = new()
            {
                new("1211","ORANGE","CONTROL PANEL", false),
                new("1171","RED","CONTROL PANEL", false),
                new("1221","RED","CONTROL PANEL", false),
                new("2241","BLUE","CONTROL PANEL", false),
                new("2373","BLUE","CONTROL PANEL", true),
                new("1173","GRAY","CONTROL PANEL", false),

                new("2241","BLUE","FHJB", false),
                new("2373","BLUE","FHJB", true),
                new("1211","ORANGE","FHJB", false),
                new("1171","RED","FHJB", false),
                new("1221","RED","FHJB", false),
                new("1173","GRAY","FHJB", false),

                new("1211","ORANGE","ENTRANCE PANEL", false),
                new("1171","RED","ENTRANCE PANEL", false),
                new("2241","BLUE","ENTRANCE PANEL", false),
                new("1221","RED","ENTRANCE PANEL", false),
                new("2373","BLUE","ENTRANCE PANEL", true),
                new("1173","GRAY","ENTRANCE PANEL", false)
            };

            SerialNumber serialNumber = new("T1234-1-1");

            LabelCreator labelCreator = new(terminalBlocks, serialNumber);

            List<string> labels = labelCreator.CreateLabels().ToList();

            Assert.AreEqual("T1234-1-1", labels[0]);
            Assert.AreEqual("", labels[1]);
            Assert.AreEqual("CP", labels[2]);
            Assert.AreEqual("1171", labels[3]);
            Assert.AreEqual("1173", labels[4]);
            Assert.AreEqual("1221", labels[5]);
            Assert.AreEqual("1211", labels[6]);
            Assert.AreEqual("", labels[7]);
            Assert.AreEqual("2241", labels[8]);
            Assert.AreEqual("2373", labels[9]);
            Assert.AreEqual("SG", labels[10]);
            Assert.AreEqual("", labels[11]);
            Assert.AreEqual("EBOX", labels[12]);
            Assert.AreEqual("1171", labels[13]);
            Assert.AreEqual("1173", labels[14]);
            Assert.AreEqual("1221", labels[15]);
            Assert.AreEqual("1211", labels[16]);
            Assert.AreEqual("", labels[17]);
            Assert.AreEqual("2241", labels[18]);
            Assert.AreEqual("2373", labels[19]);
            Assert.AreEqual("SG", labels[20]);
            Assert.AreEqual("", labels[21]);
            Assert.AreEqual("FHJB", labels[22]);
            Assert.AreEqual("1171", labels[23]);
            Assert.AreEqual("1173", labels[24]);
            Assert.AreEqual("1221", labels[25]);
            Assert.AreEqual("1211", labels[26]);
            Assert.AreEqual("", labels[27]);
            Assert.AreEqual("2241", labels[28]);
            Assert.AreEqual("2373", labels[29]);
            Assert.AreEqual("SG", labels[30]);
            Assert.AreEqual("", labels[31]);
            Assert.AreEqual(32, labels.Count);
        }

        [TestMethod]
        public void ShouldCreateCorrectLabelsIfMultipleSGLabels()
        {
            List<TerminalBlock> terminalBlocks = new()
            {
                new("1211","ORANGE","CONTROL PANEL", false),
                new("1171","RED","CONTROL PANEL", false),
                new("1221","RED","CONTROL PANEL", false),
                new("2241","BLUE","CONTROL PANEL", false),
                new("1173","GRAY","CONTROL PANEL", false),
                new("7021","BLUE","CONTROL PANEL", true),
                new("7031","BLUE","CONTROL PANEL", true),
                new("7041","BLUE","CONTROL PANEL", true),
                new("7051","BLUE","CONTROL PANEL", true),
                new("7061","BLUE","CONTROL PANEL", true),
                new("7071","BLUE","CONTROL PANEL", true),
                new("7081","BLUE","CONTROL PANEL", true),
                new("7091","BLUE","CONTROL PANEL", true),
                new("7101","BLUE","CONTROL PANEL", true),
                new("7111","BLUE","CONTROL PANEL", true),
                new("7121","BLUE","CONTROL PANEL", true),
                new("7131","BLUE","CONTROL PANEL", true),
                new("7141","BLUE","CONTROL PANEL", true),
                new("7151","BLUE","CONTROL PANEL", true),
                new("7151","BLUE","CONTROL PANEL", true),
                new("7161","BLUE","CONTROL PANEL", true),
                new("7171","BLUE","CONTROL PANEL", true),
                new("1211","ORANGE","ENTRANCE PANEL", false),
                new("1171","RED","ENTRANCE PANEL", false),
                new("1221","RED","ENTRANCE PANEL", false),
                new("2241","BLUE","ENTRANCE PANEL", false),
                new("1173","GRAY","ENTRANCE PANEL", false),
                new("7021","BLUE","ENTRANCE PANEL", true),
                new("7031","BLUE","ENTRANCE PANEL", true),
                new("7041","BLUE","ENTRANCE PANEL", true),
                new("7051","BLUE","ENTRANCE PANEL", true),
                new("7061","BLUE","ENTRANCE PANEL", true),
                new("7071","BLUE","ENTRANCE PANEL", true),
                new("7081","BLUE","ENTRANCE PANEL", true),
                new("7091","BLUE","ENTRANCE PANEL", true),
                new("7101","BLUE","ENTRANCE PANEL", true),
                new("7111","BLUE","ENTRANCE PANEL", true),
                new("7121","BLUE","ENTRANCE PANEL", true),
                new("7131","BLUE","ENTRANCE PANEL", true),
                new("7141","BLUE","ENTRANCE PANEL", true),
                new("7151","BLUE","ENTRANCE PANEL", true),
                new("7151","BLUE","ENTRANCE PANEL", true),
                new("7161","BLUE","ENTRANCE PANEL", true),
                new("7171","BLUE","ENTRANCE PANEL", true),
                new("1211","ORANGE","FHJB", false),
                new("1171","RED","FHJB", false),
                new("1221","RED","FHJB", false),
                new("2241","BLUE","FHJB", false),
                new("1173","GRAY","FHJB", false),
                new("7021","BLUE","FHJB", true),
                new("7031","BLUE","FHJB", true),
                new("7041","BLUE","FHJB", true),
                new("7051","BLUE","FHJB", true),
                new("7061","BLUE","FHJB", true),
                new("7071","BLUE","FHJB", true),
                new("7081","BLUE","FHJB", true),
                new("7091","BLUE","FHJB", true),
                new("7101","BLUE","FHJB", true),
                new("7111","BLUE","FHJB", true),
                new("7121","BLUE","FHJB", true),
                new("7131","BLUE","FHJB", true),
                new("7141","BLUE","FHJB", true),
                new("7151","BLUE","FHJB", true),
                new("7151","BLUE","FHJB", true),
                new("7161","BLUE","FHJB", true),
                new("7171","BLUE","FHJB", true)
            };

            SerialNumber serialNumber = new("T1234-1-1");

            LabelCreator labelCreator = new(terminalBlocks, serialNumber);

            List<string> labels = labelCreator.CreateLabels().ToList();

            Assert.AreEqual("T1234-1-1", labels[0]);
            Assert.AreEqual("", labels[1]);
            Assert.AreEqual("CP", labels[2]);
            Assert.AreEqual("1171", labels[3]);
            Assert.AreEqual("1173", labels[4]);
            Assert.AreEqual("1221", labels[5]);
            Assert.AreEqual("1211", labels[6]);
            Assert.AreEqual("", labels[7]);
            Assert.AreEqual("2241", labels[8]);
            Assert.AreEqual("7021", labels[9]);
            Assert.AreEqual("7031", labels[10]);
            Assert.AreEqual("7041", labels[11]);
            Assert.AreEqual("7051", labels[12]);
            Assert.AreEqual("SG", labels[13]);
            Assert.AreEqual("7061", labels[14]);
            Assert.AreEqual("7071", labels[15]);
            Assert.AreEqual("7081", labels[16]);
            Assert.AreEqual("7091", labels[17]);
            Assert.AreEqual("7101", labels[18]);
            Assert.AreEqual("SG", labels[19]);
            Assert.AreEqual("7111", labels[20]);
            Assert.AreEqual("7121", labels[21]);
            Assert.AreEqual("7131", labels[22]);
            Assert.AreEqual("7141", labels[23]);
            Assert.AreEqual("7151", labels[24]);
            Assert.AreEqual("7151", labels[25]);
            Assert.AreEqual("SG", labels[26]);
            Assert.AreEqual("7161", labels[27]);
            Assert.AreEqual("7171", labels[28]);
            Assert.AreEqual("", labels[29]);
            Assert.AreEqual("EBOX", labels[30]);
            Assert.AreEqual("1171", labels[31]);
            Assert.AreEqual("1173", labels[32]);
            Assert.AreEqual("1221", labels[33]);
            Assert.AreEqual("1211", labels[34]);
            Assert.AreEqual("", labels[35]);
            Assert.AreEqual("2241", labels[36]);
            Assert.AreEqual("7021", labels[37]);
            Assert.AreEqual("7031", labels[38]);
            Assert.AreEqual("7041", labels[39]);
            Assert.AreEqual("7051", labels[40]);
            Assert.AreEqual("SG", labels[41]);
            Assert.AreEqual("7061", labels[42]);
            Assert.AreEqual("7071", labels[43]);
            Assert.AreEqual("7081", labels[44]);
            Assert.AreEqual("7091", labels[45]);
            Assert.AreEqual("7101", labels[46]);
            Assert.AreEqual("SG", labels[47]);
            Assert.AreEqual("7111", labels[48]);
            Assert.AreEqual("7121", labels[49]);
            Assert.AreEqual("7131", labels[50]);
            Assert.AreEqual("7141", labels[51]);
            Assert.AreEqual("7151", labels[52]);
            Assert.AreEqual("7151", labels[53]);
            Assert.AreEqual("SG", labels[54]);
            Assert.AreEqual("7161", labels[55]);
            Assert.AreEqual("7171", labels[56]);
            Assert.AreEqual("", labels[57]);
            Assert.AreEqual("FHJB", labels[58]);
            Assert.AreEqual("1171", labels[59]);
            Assert.AreEqual("1173", labels[60]);
            Assert.AreEqual("1221", labels[61]);
            Assert.AreEqual("1211", labels[62]);
            Assert.AreEqual("", labels[63]);
            Assert.AreEqual("2241", labels[64]);
            Assert.AreEqual("7021", labels[65]);
            Assert.AreEqual("7031", labels[66]);
            Assert.AreEqual("7041", labels[67]);
            Assert.AreEqual("7051", labels[68]);
            Assert.AreEqual("SG", labels[69]);
            Assert.AreEqual("7061", labels[70]);
            Assert.AreEqual("7071", labels[71]);
            Assert.AreEqual("7081", labels[72]);
            Assert.AreEqual("7091", labels[73]);
            Assert.AreEqual("7101", labels[74]);
            Assert.AreEqual("SG", labels[75]);
            Assert.AreEqual("7111", labels[76]);
            Assert.AreEqual("7121", labels[77]);
            Assert.AreEqual("7131", labels[78]);
            Assert.AreEqual("7141", labels[79]);
            Assert.AreEqual("7151", labels[80]);
            Assert.AreEqual("7151", labels[81]);
            Assert.AreEqual("SG", labels[82]);
            Assert.AreEqual("7161", labels[83]);
            Assert.AreEqual("7171", labels[84]);
            Assert.AreEqual("", labels[85]);
            Assert.AreEqual(86, labels.Count);
        }

        [TestMethod]
        public void ShouldCreateCorrectLabelsIfNoSGLabels()
        {
            List<TerminalBlock> terminalBlocks = new()
            {
                new("1211","ORANGE","CONTROL PANEL", false),
                new("1171","RED","CONTROL PANEL", false),
                new("1221","RED","CONTROL PANEL", false),
                new("2241","BLUE","CONTROL PANEL", false),
                new("2373","BLUE","CONTROL PANEL", false),
                new("1173","GRAY","CONTROL PANEL", false),

                new("2241","BLUE","FHJB", false),
                new("2373","BLUE","FHJB", false),
                new("1211","ORANGE","FHJB", false),
                new("1171","RED","FHJB", false),
                new("1221","RED","FHJB", false),
                new("1173","GRAY","FHJB", false),

                new("1211","ORANGE","ENTRANCE PANEL", false),
                new("1171","RED","ENTRANCE PANEL", false),
                new("2241","BLUE","ENTRANCE PANEL", false),
                new("1221","RED","ENTRANCE PANEL", false),
                new("2373","BLUE","ENTRANCE PANEL", false),
                new("1173","GRAY","ENTRANCE PANEL", false)
            };

            SerialNumber serialNumber = new("T1234-1-1");

            LabelCreator labelCreator = new(terminalBlocks, serialNumber);

            List<string> labels = labelCreator.CreateLabels().ToList();

            Assert.AreEqual("T1234-1-1", labels[0]);
            Assert.AreEqual("", labels[1]);
            Assert.AreEqual("CP", labels[2]);
            Assert.AreEqual("1171", labels[3]);
            Assert.AreEqual("1173", labels[4]);
            Assert.AreEqual("1221", labels[5]);
            Assert.AreEqual("1211", labels[6]);
            Assert.AreEqual("", labels[7]);
            Assert.AreEqual("2241", labels[8]);
            Assert.AreEqual("2373", labels[9]);
            Assert.AreEqual("", labels[10]);
            Assert.AreEqual("EBOX", labels[11]);
            Assert.AreEqual("1171", labels[12]);
            Assert.AreEqual("1173", labels[13]);
            Assert.AreEqual("1221", labels[14]);
            Assert.AreEqual("1211", labels[15]);
            Assert.AreEqual("", labels[16]);
            Assert.AreEqual("2241", labels[17]);
            Assert.AreEqual("2373", labels[18]);
            Assert.AreEqual("", labels[19]);
            Assert.AreEqual("FHJB", labels[20]);
            Assert.AreEqual("1171", labels[21]);
            Assert.AreEqual("1173", labels[22]);
            Assert.AreEqual("1221", labels[23]);
            Assert.AreEqual("1211", labels[24]);
            Assert.AreEqual("", labels[25]);
            Assert.AreEqual("2241", labels[26]);
            Assert.AreEqual("2373", labels[27]);
            Assert.AreEqual("", labels[28]);
            Assert.AreEqual(29, labels.Count);
        }

        [TestMethod]
        public void ShouldCreateCorrectLabelsIfMultipleSameTerminals()
        {
            List<TerminalBlock> terminalBlocks = new()
            {
                new("1211","ORANGE","CONTROL PANEL", false),
                new("1171","RED","CONTROL PANEL", false),
                new("1221","RED","CONTROL PANEL", false),
                new("2241","BLUE","CONTROL PANEL", false),
                new("1173","GRAY","CONTROL PANEL", false),
                new("7021","BLUE","CONTROL PANEL", true),
                new("7031","BLUE","CONTROL PANEL", true),
                new("7041","BLUE","CONTROL PANEL", true),
                new("7051","BLUE","CONTROL PANEL", true),
                new("7061","BLUE","CONTROL PANEL", true),
                new("7071","BLUE","CONTROL PANEL", true),
                new("7081","BLUE","CONTROL PANEL", true),
                new("7091","BLUE","CONTROL PANEL", true),
                new("7101","BLUE","CONTROL PANEL", true),
                new("7111","BLUE","CONTROL PANEL", true),
                new("7121","BLUE","CONTROL PANEL", true),
                new("7131","BLUE","CONTROL PANEL", true),
                new("7141","BLUE","CONTROL PANEL", true),
                new("7151","BLUE","CONTROL PANEL", true),
                new("7151","BLUE","CONTROL PANEL", true),
                new("7151","BLUE","CONTROL PANEL", true),
                new("7151","BLUE","CONTROL PANEL", true),
                new("7151","BLUE","CONTROL PANEL", true),
                new("7161","BLUE","CONTROL PANEL", true),
                new("7171","BLUE","CONTROL PANEL", true),
            };

            SerialNumber serialNumber = new("T1234-1-1");

            LabelCreator labelCreator = new(terminalBlocks, serialNumber);

            List<string> labels = labelCreator.CreateLabels().ToList();

            Assert.AreEqual("T1234-1-1", labels[0]);
            Assert.AreEqual("", labels[1]);
            Assert.AreEqual("CP", labels[2]);
            Assert.AreEqual("1171", labels[3]);
            Assert.AreEqual("1173", labels[4]);
            Assert.AreEqual("1221", labels[5]);
            Assert.AreEqual("1211", labels[6]);
            Assert.AreEqual("", labels[7]);
            Assert.AreEqual("2241", labels[8]);
            Assert.AreEqual("7021", labels[9]);
            Assert.AreEqual("7031", labels[10]);
            Assert.AreEqual("7041", labels[11]);
            Assert.AreEqual("7051", labels[12]);
            Assert.AreEqual("SG", labels[13]);
            Assert.AreEqual("7061", labels[14]);
            Assert.AreEqual("7071", labels[15]);
            Assert.AreEqual("7081", labels[16]);
            Assert.AreEqual("7091", labels[17]);
            Assert.AreEqual("7101", labels[18]);
            Assert.AreEqual("SG", labels[19]);
            Assert.AreEqual("7111", labels[20]);
            Assert.AreEqual("7121", labels[21]);
            Assert.AreEqual("7131", labels[22]);
            Assert.AreEqual("7141", labels[23]);
            Assert.AreEqual("7151", labels[24]);
            Assert.AreEqual("7151", labels[25]);
            Assert.AreEqual("7151", labels[26]);
            Assert.AreEqual("7151", labels[27]);
            Assert.AreEqual("7151", labels[28]);
            Assert.AreEqual("SG", labels[29]);
            Assert.AreEqual("7161", labels[30]);
            Assert.AreEqual("7171", labels[31]);
            Assert.AreEqual("", labels[32]);
            Assert.AreEqual(33, labels.Count);
        }
    }
}