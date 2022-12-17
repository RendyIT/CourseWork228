using CourseWorkProgram.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CourseWorkProgram.MainWindow;

namespace CourseWorkProgram
{
    class FileIOService
    {

        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<VideoCard> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<VideoCard>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<VideoCard>>(fileText);
            }
        }
        public BindingList<CPU> LoadData1()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<CPU>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<CPU>>(fileText);
            }
        }
        public void SaveData(BindingList<VideoCard> dgList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(dgList);
                writer.Write(output);
            }
        }
        public void SaveData1(BindingList<CPU> bdList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(bdList);
                writer.Write(output);
            }
        }
    }
}

