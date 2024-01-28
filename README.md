# L-Systems-Plant-Simulation
***Table of Contents:***

1. [What is L-system?](#what-is-l-system)
2. [Context-Free L-system](#context-free-l-system)
3. [Chomsky Normal Form](#chomsky-normal-form)
4. [Difference between L-system and Chomsky Normal Form](#difference-between-l-system-and-chomsky-normal-form)
5. [Turtle Graphics](#turtle-graphics)
    - [Explanation of how Turtle Graphics can simulate plant growth](#explanation-of-how-turtle-graphics-can-simulate-plant-growth)
    - [Examples of plant growth simulation](#examples-of-plant-growth-simulation)
6. [Basic Turtle Graphics Symbols and Functions](#basic-turtle-graphics-symbols-and-functions)
7. [Using L-System Code in Unity](#using-l-system-code-in-unity)
    - [1. Attach the Script to GameObject](#1-attach-the-script-to-gameobject)
    - [2. Adjust Parameters in the Unity Inspector](#2-adjust-parameters-in-the-unity-inspector)
    - [3. Generate L-System](#3-generate-l-system)
    - [4. Update and Reset](#4-update-and-reset)
    - [Example Usage](#example-usage)
8. [Using Command Line for L-System Tree Simulation](#using-command-line-for-l-system-tree-simulation)
    - [1. Extract Build Files](#1-extract-build-files)
    - [2. Run the Executable](#2-run-the-executable)
    - [3. Execute Commands via Command Line](#3-execute-commands-via-command-line)
    - [4. Unity Console Commands Integration](#4-unity-console-commands-integration)
9. [Example Images](#example-images)

**What is L-system?**

An **L-system**, or **Lindenmayer system**, is a parallel rewriting
system and a type of formal grammar. It was introduced and developed in
1968 by Aristid Lindenmayer, a Hungarian theoretical biologist and
botanist at the University of
Utrecht].

An L-system consists of:

-   An alphabet of symbols that can be used to make strings.

-   A collection of production rules that expand each symbol into some
    larger string of symbols.

-   An initial "axiom" string from which to begin construction.

-   A mechanism for translating the generated strings into geometric
    structures.

Lindenmayer used L-systems to describe the behavior of plant cells and
to model the growth processes of plant development.They have also been
used to model the morphology of a variety of organisms and can be used
to generate self-similar
fractals.The recursive nature
of the L-system rules leads to self-similarity and thereby, fractal-like
forms are easy to describe with an
L-system.

**Context free L-system**

A **context-free L-system**, also known as a **0L-system**, is a type
of Lindenmayer system where the production rules are applied to symbols
regardless of their context within the
string.This
means that the application of the rules does not depend on the
neighboring symbols in the
string.

A context-free L-system is denoted by **G = (V, ω,
P)**,
where:

-   **V** is an alphabet, which is a set of symbols that can be used to
    make strings.

-   **ω** (omega) is the initial "axiom" string from which to begin
    construction.

-   **P** is a finite set of production rules that expand each symbol
    into some larger string of
    symbols.
    A production rule is denoted by **a → x**, where **a** is a symbol
    in **V** and **x** is a string of symbols
    in **V**.

**Chomsky Normal Form**

 CNF is a specific type of context-free grammar (CFG). A CFG is in CNF
if all its production rules are of the form:

-   A → BC

-   A →a

> where A, B, and C are non-terminal symbols and a is a terminal
> symbol.
> CNF is used as a preprocessing step for many algorithms for CFG like CYK
> (membership algo), bottom-up parsers
> etc.
> For generating string w of length 'n' requires '2n-1' production or steps in CNF


**Difference between L-system and Chomsky Normal Form**

Both CNF and L-systems are types of formal grammars, they are used in
different contexts and have different rules and structures. CNF is used
in parsing algorithms in compilers, while L-systems are used in modeling
and simulation of biological systems and in the generation of graphics
and animations.

 The essential difference between Chomsky grammars and L-systems lies in
the method of applying productions. In Chomsky grammars productions are
applied sequentially, whereas in L-systems they are applied in parallel,
replacing simultaneously all letters in a given word. This difference
reflects the biological motivation of L-systems. Productions are
intended to capture cell divisions in multicellular organisms, where
many division may occur at the same time.

**Turtle Graphics**are often used for L-System interpretation:

The derivation strings of developing L-systems can be interpreted as a
linear sequence of instructions (with real-valued parameters in the case
of parametric L-systems) to a 'turtle', which interprets the
instructions as movement and geometry building actions. The historical
term turtle interpretation comes from the early days of computer
graphics, where a mechanical robot turtle (either real or simulated),
capable of simple movement and carrying a pen, would respond to
instructions such as 'move forward', 'turn left', 'pen up' and 'pen
down'. Each command modifies the turtle's current position, orientation
and pen position on the drawing surface. The cumulative product of
commands creates the drawing.

The turtle is represented by its state, which consists of turtle
position and orientation in the Cartesian coordinate system, as well as
various attribute values, such as current color and line width. The
position is defined by a vector $\overrightarrow{P}$ , and the
orientation is defined by three vectors $\overrightarrow{H}$,
$\overrightarrow{L}$, and $\overrightarrow{U}$, indicating the turtle's
heading and the directions to the left and up. These vectors have unit
length, are perpendicular to each other, and satisfy the equation:

$$\overrightarrow{H} \times \overrightarrow{L} = \overrightarrow{U}$$

. Rotations of the turtle are expressed by the equation:

$$ 
(\overrightarrow{H'}, \overrightarrow{L'}, \overrightarrow{U'}) = (\overrightarrow{H}, \overrightarrow{L}, \overrightarrow{U})
$$



where R is a 3 $\times$ 3 rotation matrix . Changes in the turtle's
state are caused by interpretation of specific symbols, each of which
may be followed by parameters. If one or more parameters are present,
the value of the first parameter affects the turtle's state. If the
symbol is not followed by any parameter, default values specified
outside the L-system are used. The following list specifies the basic
set of symbols interpreted by the turtle.
![image](https://github.com/Salam-Nik/L-Systems-Plant-Simulation/blob/main/sample/image.png)

a\) Controlling the turtle in three dimensions   b) Example of the turtle
interpretation of a string

| **Symbol** | **Function** |
|------------|--------------|
| F          | move forward at distance **L** (Step Length) and draw a line |
| f          | move forward at distance **L** (Step Length) without drawing a line |
| +          | turn left **A** (Default Angle) degrees |
| -          | turn right **A** (Default Angle) degrees |
| \\         | roll left **A** (Default Angle) degrees |
| /          | roll right **A** (Default Angle) degrees |
| ^          | pitch up **A** (Default Angle) degrees |
| &          | pitch down **A** (Default Angle) degrees |
| \|         | turn around 180 degrees |
| J          | insert point at this position |
| "          | multiply current length by **dL** (Length Scale) |
| !          | multiply current thickness by **dT** (Thickness Scale) |
| [          | start a branch (push turtle state) |
| ]          | end a branch (pop turtle state) |
| #          | increase the value of the current line width by the default width increment |
| ;          | index of the color map to n, or increase the value of the current index by the default colour increment if no parameter is given |
| ,          | index of the color map to n, or decrease the value of the current index by the default colour decrement if no parameter is given |
| A,B,C,D,...| placeholders, used to nest other symbols |

### Employing L-System Code in Unity

To implement the provided L-System code in Unity, follow these steps:

#### 1. Attach the Script to GameObject

- Attach the `LSystem` script to a GameObject in your Unity scene.

#### 2. Adjust Parameters in the Unity Inspector

- **Iterations:** Set the number of iterations for the L-System.
- **Angle:** Adjust the rotation angle for turns in the L-System.
- **Width:** Modify the width of branches or lines in the L-System.
- **Length:** Change the length of branches or the step length in the L-System.
- **Axiom:** Define the initial axiom for the L-System.
- **Rules:** Add or modify rules for the L-System using the Inspector.

#### 3. Generate L-System

- Click the "Generate" button in the Unity Inspector or trigger the generation through code when needed.
- The L-System will be created based on the specified parameters and rules.

#### 4. Update and Reset

- The L-System can be updated dynamically by changing parameters like iterations, angle, width, and length.
- Use the "UpdateTree" method to dynamically update the L-System during runtime.
- To reset the L-System to default values, use the "Reset" method.

#### Example Usage:

```csharp
// Example of modifying L-System parameters during runtime
void Update()
{
    // Dynamically adjust parameters
    lSystem.SetIterations(5);
    lSystem.SetAngle(25f);
    lSystem.SetWidths(0.8f);
    lSystem.SetLength(1.5f);

    // Update the L-System
    lSystem.UpdateTree();
}
```
### Using Command Line for L-System Tree Simulation

To interact with the L-System simulation via the command line, follow these steps:

#### 1. Extract Build Files

- Extract the contents of the provided `build.rar` file.

#### 2. Run the Executable

- Locate and run the `L-Systems Plant Simulation.exe` file.

#### 3. Execute Commands via Command Line

- In the Unity console, you can use the following commands to manipulate the L-System simulation:

    - **reset:** Reset the L-System to default values.
    ```bash
    reset
    ```

    - **set-iterations [iter]:** Set the number of iterations for the L-System.
    ```bash
    set-iterations 5
    ```

    - **set-angle [newVal]:** Adjust the rotation angle for turns in the L-System.
    ```bash
    set-angle 25.0
    ```

    - **set-widths [newVal]:** Modify the width of branches or lines in the L-System.
    ```bash
    set-widths 0.8
    ```

    - **set-length [newVal]:** Change the length of branches or the step length in the L-System.
    ```bash
    set-length 1.5
    ```

    - **set-axiom [newVal]:** Define the initial axiom for the L-System.
    ```bash
    set-axiom X
    ```

    - **add-rule [key1] [value1]:** Add or modify rules for the L-System.
    ```bash
    add-rule X "[-FX]X[+FX][+F-FX]"
    ```

    - **generate:** Update and generate the L-System based on the provided parameters and rules.
    ```bash
    generate
    ```

https://github.com/Salam-Nik/L-Systems-Plant-Simulation/assets/117828440/1f497504-c024-46cf-bfe2-c94f6e30ad8e



![](https://github.com/Salam-Nik/L-Systems-Plant-Simulation/blob/main/sample/example.mp4)
### Example Images

Here are visual examples of L-System plant simulations generated using Turtle Graphics in Unity:

1. ![Example Image 1](insert_image_url_1)
   -             'X'=> "[F[-X+F[+FX]][*-X+F[+FX]][/-X+F[+FX]-X]]" ,
            'F'=> "FF" 

2. ![Example Image 2](https://github.com/Salam-Nik/L-Systems-Plant-Simulation/blob/main/sample/example2.png)
   -              'X'=> "[FX[+F[-FX]FX][-F-FXFX]]" ,
             'F'=> "FF" 

3. ![Example Image 3](insert_image_url_3)
   -            'X'=> "[F-[X+X]+F[+FX]-X]" ,
           'F'=> "FF" 

Feel free to explore and experiment with the provided L-System code to create diverse and visually appealing tree structures in Unity.

Now you can interact with the L-System simulation both through the command line and the Unity console, providing a flexible and dynamic way to control and observe the generated tree structures.

This code demonstrates how to interact with the L-System during runtime, changing its parameters and updating the generated structure.

Feel free to integrate this L-System code into your Unity project for dynamic and procedural generation of tree-like structures. Adjust parameters and rules to achieve diverse and visually appealing results.
