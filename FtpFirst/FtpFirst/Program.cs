// using System.Net;

// var request = FtpWebRequest.Create("ftp://eu-central-1.sftpcloud.io");
// request.Method = WebRequestMethods.Ftp.ListDirectory;
//
// request.Credentials = new NetworkCredential("fa33f0198fd0437bb353e9e010467cb7", "RrLSALWp2aJS2hMH182hy3UfcXMWpaCE");
//
// using var response = (FtpWebResponse)request.GetResponse();
//
// using var responseStream = response.GetResponseStream();
//
// using var reader = new StreamReader(responseStream);
//
// while (!reader.EndOfStream)
// {
//     var line = reader.ReadLine();
//     Console.WriteLine(line);
// }

// var request = WebRequest.Create("ftp://eu-central-1.sftpcloud.io/aloha/example.txt");
//
// request.Method = WebRequestMethods.Ftp.DownloadFile;
//
// request.Credentials = new NetworkCredential("fa33f0198fd0437bb353e9e010467cb7", "RrLSALWp2aJS2hMH182hy3UfcXMWpaCE");
// using var response = request.GetResponse();
// using var responseStream = response.GetResponseStream();
//
// using var fileStream = File.Create("example.txt");
//
// responseStream.CopyTo(fileStream);
//
// Console.WriteLine("File downloaded successfully.");


// var request = WebRequest.Create("ftp://eu-central-1.sftpcloud.io/aloha/test.txt");
// request.Method = WebRequestMethods.Ftp.UploadFile;
//
// request.Credentials = new NetworkCredential("fa33f0198fd0437bb353e9e010467cb7", "RrLSALWp2aJS2hMH182hy3UfcXMWpaCE");
// var filePath = "test.txt";
//
// using var fileStream = File.OpenRead(filePath);
//
// using var requestStream = request.GetRequestStream();
//
// fileStream.CopyTo(requestStream);
//
// Console.WriteLine("File uploaded successfully.");
//
