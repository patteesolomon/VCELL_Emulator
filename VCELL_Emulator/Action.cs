namespace VCELL_Emulator
{
        ///
        /// <Summary>
        /// keeping it basic for now. ill add a task search so it can pull from a list of stuff that'll
        /// find a proper action to take...
        /// </Summary>
        /// 
        public class Action 
        {
            public Think idea;
            public string what;
            public int times;
            public enum thing  
            {
                ACT,
                ATTACK,
                TALK,
                THINK,
                FEEL, // aparatus operandi
                HEAR,
                RECOG, // refers to the cognative processes and calls
                       // anything related to relevent data. eg. answers, solutions
                       // related processes of cognition. eg.
                       // Philisophical: "The meaning of life."
            };
        }
}
