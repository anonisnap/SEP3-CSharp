namespace ServerCommunication {
	public class RequestReply {
		public int Id { get; set; }
		public string ClassName { get; set; }
		public object Arg { get; set; }

		public RequestReply(int id, string className, object arg) {
			Id = id;
			ClassName = className;
			Arg = arg;
		}
	}
}