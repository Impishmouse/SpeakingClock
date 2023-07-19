using System.Threading.Tasks;
using UnityEngine;

namespace Commands
{
    [CreateAssetMenu(fileName = "CommandsRunner", menuName = "ScriptableObjects/CommandsRunner")]
    public class CommandsRunner : ScriptableObject
    {
        public async Task Execute(ICommand command)
        {
            await command.Execute();
        }
    }

    public interface ICommand
    {
        Task Execute();
    }
}