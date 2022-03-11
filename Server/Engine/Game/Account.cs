
using System;
using System.Net;

namespace Server.Accounting
{
	public interface IAccount : IGoldAccount, IComparable<IAccount>
	{
		[CommandProperty(AccessLevel.Administrator, true)]
		string Username { get; set; }

		[CommandProperty(AccessLevel.Administrator, true)]
		string Email { get; set; }

		[CommandProperty(AccessLevel.Administrator, AccessLevel.Owner)]
		AccessLevel AccessLevel { get; set; }

		[CommandProperty(AccessLevel.Administrator)]
		int Length { get; }

		[CommandProperty(AccessLevel.Administrator)]
		int Limit { get; }

		[CommandProperty(AccessLevel.Administrator)]
		int Count { get; }

		[CommandProperty(AccessLevel.Administrator, true)]
		DateTime Created { get; set; }

		[CommandProperty(AccessLevel.Administrator, true)]
		DateTime LastLogin { get; set; }

		[CommandProperty(AccessLevel.Administrator, true)]
		IPAddress[] LoginIPs { get; set; }

		[CommandProperty(AccessLevel.Administrator)]
		TimeSpan Age { get; }

		[CommandProperty(AccessLevel.Administrator)]
		TimeSpan TotalGameTime { get; }

		[CommandProperty(AccessLevel.Administrator)]
		bool Banned { get; set; }

		[CommandProperty(AccessLevel.Administrator)]
		bool Young { get; set; }

		Mobile this[int index] { get; set; }

		void Delete();

		string GetPassword();
		void SetPassword(string password);
		bool CheckPassword(string password);
	}
}