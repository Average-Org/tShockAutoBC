﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using TShockAPI;

namespace AutoBC
{
	public class Config
	{
		public List<BCMessage> messages = new List<BCMessage> { new BCMessage("[Broadcast] This is a test broadcast, the owner has yet to set up this plugin!", new Color(255, 255, 255), new List<string>() { "time noon"} ) };

			public int bcInterval = 3; //MINUTES


			public void Write()
			{
				string path = Path.Combine(TShock.SavePath, "AAutoBC.json");
				File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
			}
			public static Config Read()
			{
				string filepath = Path.Combine(TShock.SavePath, "AAutoBC.json");
				try
				{
					Config config = new Config();

					if (!File.Exists(filepath))
					{
						File.WriteAllText(filepath, JsonConvert.SerializeObject(config, Formatting.Indented));
					}
					config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(filepath));
					

					return config;
				}
				catch (Exception ex)
				{
					TShock.Log.ConsoleError(ex.ToString());
					return new Config();
				}
			}
	}
}
