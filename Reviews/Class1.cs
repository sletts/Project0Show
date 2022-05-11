/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviews
{
    public class Class1
    {
        public void addReview(string[] review){
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Reviews.txt")))
            {
                foreach (string line in review)
                    outputFile.WriteLine(line);
            }
        }
    }
}*/
