namespace Web
{
	public class RequestResultData
	{
		public string Text { get; set; }

		public string Error { get; set; }

		public bool IsSuccess
		{
			get { return string.IsNullOrEmpty(Error); }
		}
	}
}