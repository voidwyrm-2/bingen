namespace Bingen
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("expected 'bingen [path to a .plbin file]'");
                return;
            }

            string inpath = args[0].Trim();

            if (!Path.Exists(inpath))
            {
                Console.WriteLine($"path '{inpath}' does not exist");
                return;
            }
            else if (Path.GetExtension(inpath) != ".plbin")
            {
                Console.WriteLine($"path '{inpath}' is not a .plbin file");
                return;
            }

            string outpath = Path.GetFileNameWithoutExtension(inpath) + ".bin";
            if (Path.Exists(outpath))
            {
                Console.WriteLine($"output path '{outpath}' already exists, do you want to overwrite it?(y/n)");
                while (true)
                {
                    string? reply = Console.ReadLine();
                    switch (reply)
                    {
                        case "y":
                            break;
                        case "n":
                            return;
                        default:
                            Console.WriteLine($"invalid reply '{reply}'");
                            continue;
                    }
                    break;
                }
            }

            string content;
            try
            {
                content = File.ReadAllText(inpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            try
            {
                byte[] bytes = GenerateBytes(content);

                File.WriteAllBytes(outpath, bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        static byte[] GenerateBytes(string text)
        {
            LinkedList<byte> o = new();

            foreach (string bs in text.Replace('\n', ',').Split(','))
            {
                try
                {
                    o.AddLast(Convert.ToByte(bs));
                }
                catch
                {
                    throw new Exception($"invalid byte '{bs}'");
                }
            }

            return [.. o];
        }
    }
}