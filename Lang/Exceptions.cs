namespace StorySystem.Lang
{

	[System.Serializable]
	public class ParsingException : System.Exception
	{
		public ParsingException() { }
		public ParsingException(string message) : base(message) { }
		public ParsingException(string message, System.Exception inner) : base(message, inner) { }
		protected ParsingException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}