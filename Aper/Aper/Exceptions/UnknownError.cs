namespace Aper.Exceptions;
public class UnknownError: Xeptions.Xeption
{
	public UnknownError() :
		base(message: "Unknown error accoured. Contact support.")
		{ }
}
