using System;

partial class Sea
{
	public bool Equals(Sea seaName)
	{
		if (seaName == null)
		{
			return false;
		}
		else
		{
			return this.SeaName == seaName.SeaName;
		}
	}
	public void GetType()
	{
		Console.WriteLine($"Type: {this.SeaName.GetType()}");
	}
	public void GetHashCode()
	{
		Console.WriteLine($"Hashcode: {this.SeaName.GetHashCode()}");
	}
}
