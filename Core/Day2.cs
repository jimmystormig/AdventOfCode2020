using System.Linq;

namespace Core
{
    public class Day2
    {
        private readonly string _password;
        private readonly Policy _policy;

        public Day2(string password, Policy policy)
        {
            _password = password;
            _policy = policy;
        }

        public bool SatisfiesPolicy() => _policy.Satisfies(_password);

        public abstract class Policy
        {
            protected readonly (int start, int end) _range;
            protected readonly char _letter;

            protected Policy((int Start, int End) range, char letter)
            {
                _range = range;
                _letter = letter;
            }

            public abstract bool Satisfies(string password);
        }
        
        public class OldPolicy : Policy
        {
            public OldPolicy((int Start, int End) range, char letter) : base(range, letter) { }
            
            public override bool Satisfies(string password)
            {
                var count = password.Count(x => x == _letter);
                return _range.start <= count && count <= _range.end;
            }
        }
        
        public class NewPolicy : Policy
        {
            public NewPolicy((int Start, int End) range, char letter) : base(range, letter) { }
            
            public override bool Satisfies(string password)
            {
                var pos1IsCorrect = password.Substring(_range.start - 1, 1).ToCharArray()[0].Equals(_letter);
                var pos2IsCorrect = password.Substring(_range.end - 1, 1).ToCharArray()[0].Equals(_letter);

                return (!pos1IsCorrect || !pos2IsCorrect) && (pos1IsCorrect || pos2IsCorrect);
            }
        }
    }
}