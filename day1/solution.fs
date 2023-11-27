namespace Day01

open System.IO

module private InternalModule =
    let calculateCaloriesPerElves () =
        let inputFilePath = Path.Combine(__SOURCE_DIRECTORY__, "input.txt")
        let perElfInputData = File.ReadAllText(inputFilePath).Split("\n\n")

        Array.map (fun (line: string) ->
            line.Split("\n")
            |> Array.map int
            |> Array.sum
        ) perElfInputData
        |> Array.sortDescending

module Part1 =
    let run () =
        let caloriesPerElves = InternalModule.calculateCaloriesPerElves()
        caloriesPerElves[0]

module Part2 =
    let run () =
        let caloriesPerElves = InternalModule.calculateCaloriesPerElves()
        Array.take 3 caloriesPerElves
        |> Array.sum
