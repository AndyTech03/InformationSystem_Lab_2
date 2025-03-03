﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class EventLogData : IFileData
	{
		public enum EventLogType
		{
			ProgrammStart,
			ProgrammStop,
			UserLogIn,
			UserAfk,
			UserReLogIn,
			UserLogOut,
			LoginFailture,
			ConfigChanged,
			LogsGziped,
			LogsUnGziped,
			UserDataAction,
			UserDataChainged,
			UserBlocked, 
			UserUnBlocked,
			UserRegisrated,
			DataReaded,
			DataReadingAnauthorized,
			DataUpdated,
			DataUpdatingAnauthorized,
			WatcherStart,
			WatcherStop,
		}
		private static Dictionary<string, EventLogType> TypesStrings = null;

		public DateTime eventDateTime { get; private set; }
		public EventLogType eventType { get; set; }
		public Guid userUuid { get; private set; }
		public IPAddress userIp { get; private set; }
		public string eventDetail { get; private set; }

		public EventLogData() { }
		public EventLogData(EventLogType eventType, Guid userUuid, IPAddress userIp, string eventDetail)
		{
			this.eventDateTime = DateTime.Now;
			this.eventType = eventType;
			this.userUuid = userUuid;
			this.userIp = userIp;
			this.eventDetail = eventDetail;
		}

		private static void FillTypes()
		{
			if (TypesStrings != null) 
				return;
			TypesStrings = new Dictionary<string, EventLogType>();
			for (int typeId = (int)EventLogType.ProgrammStart; typeId <= (int)EventLogType.WatcherStop; typeId++)
			{
				EventLogType type = (EventLogType)typeId;
				TypesStrings.Add(type.ToString(), type);
			}
		}

		public IFileData FromLine(string line)
		{
			string[] data = line.Split('\t');
			return new EventLogData
			{
				eventDateTime = DateTime.Parse(data[0]),
				eventType = FromString(data[1]),
				userUuid = Guid.Parse(data[2]),
				userIp = IPAddress.Parse(data[3]),
				eventDetail = data[4],
			};
		}

		public static EventLogType FromString(string typeString)
		{
			FillTypes();
			return TypesStrings[typeString];
		}

		public string ToLine()
		{
			return $"{eventDateTime}\t{eventType}\t{userUuid}\t{userIp}\t{eventDetail}";
		}
	}
}
