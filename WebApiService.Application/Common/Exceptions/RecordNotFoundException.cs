namespace WebApiService.Application.Common.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string name, object key)
            : base(String.Format("Запись в таблице \"{0}\" с идентификатором ({1}) не найдена.", name, key)) { }
    }
}