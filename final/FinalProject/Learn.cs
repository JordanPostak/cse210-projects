using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    public class Learn: Program
    {

        
        public static void LearnSevenSteps() 
        {
            Console.Clear();
            Console.WriteLine();
            TypingEffect("These 7 steps are a way to develop a deeper relationship with God by listening to the promptings of the Holy Spirit and acting on them.\n");
            TypingEffect("The steps begin with listening for spiritual insights and promptings, and then recording them in a smaller journal, a place to keep all of your thoughts, feelings and inspirations you receive throughout the day, in order to ponder them later that day, or whenever you get a chance.\n");
            TypingEffect("The next steps involve reflecting on the promptings, what they mean, what can be done about them, what can be done about them and then making plans to act on them.\n");
            TypingEffect("The final steps involve reviewing the blessings received from following the promptings and inspirations you received, give thanks to your creator and record them in a larger journal.\n");
            TypingEffect("These steps are a way to seek personal revelation and guidance from God, and to recognize and act on the promptings we receive from the Holy Spirit. As you follow these steps, more light will come into your life.\n\n");
            PromptToContinue();
            LearnListen();
            PromptToContinue();
            LearnReceive();
            PromptToContinue();
            LearnPonder();
            PromptToContinue();
            LearnPlan();
            PromptToContinue();
            LearnAct();
            PromptToContinue();
            LearnReview();
            PromptToContinue();
            LearnRecord();
        }

        public static void LearnListen() 
        {   
            TypingEffect("Listen: Be aware of the spiritual insights or promptings that you receive from the Holy Spirit. To do this, engage in activities that bring more light into your life and avoid those that diminish it. Make lists of positive things in your life to help you recognize and reinforce the light you already have within you. Try your best to see the good in any nagative situation. There is always a streanth behind every weakness. Listen closely and you will descover what it is. Pray to Heavenly Father for guidance so that you can learn how to turn your weaknesses into streanths. Once you do, add it to the list of positive things in your life.\n\n");
            
        }

        public static void LearnReceive() 
        {
            TypingEffect("Receive: Any time you get an idea that feels inspired, write it down! Write down all the promptings that you receive from the Holy Spirit in a small journal, or a place where you can easily and quickly record the initial thought so that you can ponder it later on and look deeper into it. It might be helpful to take a quick note of the way that you feel when you initially get this idea or impression. You can get these impressions and inspirations when you kneel down to pray, while dreaming, reading scriptures, or just going about your day. Just be sure to record them while they are fresh in your mind.\n\n");
            
        }

        public static void LearnPonder() 
        {

            TypingEffect("Ponder: Ponder a little deeper about the feeling when you have time to sit down and study a little. What you want to do is pay attention to weather or not this really rings true to you. Search the scriptures, find support for the idea or an example of it. Search the words of church leaders and authorities, the words of Prophets and Apostles, to find any example or support of it. If you didn't have enough time to study it out, set it aside for later, but if you've exhausted all efforts to find any support of it in the scriptures or in the words of church leaders and authorities, abandon it all together. Figure out if it fits more along the lines of a Pearl of knowledge, a simple task, a habit, or a mission. Compare it to the scriptures and words of the prophets. \n\n");
        }

        public static void LearnPlan() 
        {
            
            TypingEffect("Plan: Take your ideas to God in prayer and express gratitude for the revelations and promptings. If it is a pearl of Knowledge, you need not make any plans for it, but have it in mind to review it and record it at some point. If it is a Task, Habit or Mission, ask for guidance in planning and acting on it. Tasks are one time events that usually have a date or time for it to be completed by. A Habit usually has a set pattern for how often you want it to be acheived and for how long. The goal of a habit is to force yourself for a certain period of time until it becomes a habit you do naturally anyways.At the end of the set time and date, even if you could improve on it and its not perfect, still continue on with it to the next steps. Missions are bigger Tasks that are a little more vague. Usually its hard to plan out a mission and needs the aid of creating sub tasks and habits in order to get there. Think about all you need to do to acheive your mission, then write down those things as tasks or habits. It might also be good to note which inspiration they came from if you have a way to keep track of them. Once you have those figured out pick a date that the whole mission will be completed and consider this inspiration planned for, you can plan out the sub tasks and habits later whenever you have time. This step is good to use a planner with, so that you can see how your missions and habits can trickle in down to even daily, and your tasks fit around them nicely. After a while of doing this, you will start to see your planner fill up every day.\n\n");
        }

        public static void LearnAct() 
        {
            
            TypingEffect("Act: Act on all the instructions given to you by the Holy Spirit. The reason you will start to see your planner filling up every day the more often you do this is because you are hearing Him more often! You are constantly filling yourself up with light as you act on the promptings and inspirations you receive. The Heavens rejoyce when you do so and the Lord will see fit to use you as a vesel to accomplish important work. Check your planner daily, the work of the Lord may fill it up, but He promises, that as you take His yoke upon yourself, you will have an increadable ability to do them with ease, as He says, His burdens are light. Be flexible and open to changes in your plans as you receive more promptings. There is much work to be done!\n\n");
        }

        public static void LearnReview() 
        {
            
            TypingEffect("Review: Express gratitude to Heavenly Father for the blessings you've received from following the promptings and acting on the instructions. It is also important to thank Heavenly Father for the  Pearls of knowledge and wisdom you have received. You will reap the benifits and be filled with the Spirit as you do this step. The amount that you can grow spiritually as you kneel in prayer to your Heavenly Father for this purpose is more than words themselves can express.\n\n");
        }

        public static void LearnRecord() 
        {
            
            TypingEffect("Record: Write down your experiences, the knowledge you've received, and the blessings you've obtained in a larger journal, one that is a bit more suited to be read by those who come after you. Make sure to write the date, circumstances and events that have followed as a result of following through on your inspirations, or pondering and reviewing Pearls on Knowledge. Testify of Christ and share these experiences with others who may benefit from them. Promptings to share your testimony of eternal truths that you have learned from these things should be added as another inspiration received. But remember that by doing so, it is because of an inspiration from the Holy Ghost and should not be done because of a personal judgment about another person. These testimonies and this journal is primarily for your posterity and for the people you love who will come after you have left this globe.\n\n");
        }

        public static void PromptToContinue()
        {
            Console.WriteLine("Press Enter to continue or type 'exit' to return to the main menu:");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Returning to main menu...");
                // Add code here to return to the main menu
            }
        }

                protected override void Menu()
        {

            while (true)
            {
                Console.WriteLine();
                Inspire.DisplayLuminosity();
                TypingEffect("Select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Learn about the Seven Steps");
                Console.WriteLine("4. Return to Main Menu");
                Console.WriteLine();
                BlinkIndicator();

                string input = Console.ReadLine();
                int selection;
                if (Int32.TryParse(input, out selection))
                {
                    switch (selection)
                    {
                        case 1:
                            Console.Clear();
                            LearnSevenSteps();
                            break;
                        case 2:
                            return;
                        default:
                            Console.WriteLine("Invalid input, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            } 
        }

        public void Run()
        {
            Menu();
        }

    }
}
