﻿
    ____              __  ______       ____________    _________________________________________________
   / __ \__  ______  / / / / __ \     / ____/ ____/    Server Acknowledgement: © The RunUO Software Team
  / /_/ / / / / __ \/ / / / / / /    / /   / __/         RunUO Initialized On: 05/01/2002 (mm/dd/yyyy)
 / _, _/ /_/ / / / / /_/ / /_/ /    / /___/ /___       *************************************************
/_/ |_|\__,_/_/ /_/\____/\____/_____\____/_____/        This file is maintained by: www.uoavocation.net
                                                 
________________________________________________________________________________________________________

Original Author

███████╗███████╗██████╗░░█████╗░██████╗░░█████╗░░██╗░░░░░░░██╗███╗░░██╗███████╗██████╗░
╚════██║██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗░██║░░██╗░░██║████╗░██║██╔════╝██╔══██╗
░░███╔═╝█████╗░░██████╔╝██║░░██║██║░░██║██║░░██║░╚██╗████╗██╔╝██╔██╗██║█████╗░░██║░░██║
██╔══╝░░██╔══╝░░██╔══██╗██║░░██║██║░░██║██║░░██║░░████╔═████║░██║╚████║██╔══╝░░██║░░██║
███████╗███████╗██║░░██║╚█████╔╝██████╔╝╚█████╔╝░░╚██╔╝░╚██╔╝░██║░╚███║███████╗██████╔╝
╚══════╝╚══════╝╚═╝░░╚═╝░╚════╝░╚═════╝░░╚════╝░░░░╚═╝░░░╚═╝░░╚═╝░░╚══╝╚══════╝╚═════╝░
2020

Author Comments

[i] "AI_ActionAI" should never be assigned to any mobile that wasn't designed for the ActionAI mobile system; 
    doing so could cause your server to crash unexpectedly (*you have been warned*)

>>> [✔] Added ActionAI.cs
         • this new AIType brings NPCs to life by making them do the jobs they chose for their 
           profession; that means fishers (fish), lumberjacks (chop trees), miners (dig and excavate).
         • in addition this new AI brings a new Pirate system and introduces wandering Caravans;
           these caravans are vendors who walk from city to city and sell goods to players