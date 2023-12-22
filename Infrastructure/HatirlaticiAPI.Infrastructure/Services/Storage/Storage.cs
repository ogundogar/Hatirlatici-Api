using HatirlaticiAPI.Infrastructure.Operations;

namespace HatirlaticiAPI.Infrastructure.Services.Storage
{
    public class Storage
    {
        protected delegate bool HasFile(string pathOrContainerName, string fileName);
        protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName,HasFile hasFileMethod, bool first = true)
        {
            string newFileName = await Task.Run<string>(async () =>
            {

                string extension = Path.GetExtension(fileName);
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
                if (hasFileMethod(pathOrContainerName, fileName))
                {
                    string name = Path.GetFileNameWithoutExtension(newFileName);
                    if (name.IndexOf("-") == -1)
                    {
                        return await FileRenameAsync(pathOrContainerName, $"{name}-1{extension}", hasFileMethod, false);
                    }
                    else
                    {
                        string[] number = name.Split('-');
                        name = name.Replace($"-{number[1].Trim()}", $"-{((int.Parse(number[1].Trim()) + 1).ToString())}");
                        return await FileRenameAsync(pathOrContainerName, $"{name}{extension}", hasFileMethod, false);
                    }
                }
                else
                    return newFileName;
            });
            return newFileName;
        }
    }
}
