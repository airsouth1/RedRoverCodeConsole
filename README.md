# Red Rover Coding Excercise
This repository demonstrates a basic implementation of the Red Rover Code Puzzle exercise found at <https://github.com/RedRoverK12/Red-Rover-Code-Puzzle>.  The full assignment is also provided at the bottom of this README for reference.

## Approach
The approach taken was to quickly and simply design a solution to the details provided, while capturing any assuptions and questions to feed future iterations of the design.  Some basic tenents utilized:
* Solve the problem in the most rudimentary and simplistic way that is easily maintainable and direct
* Solve the problem first and foremost, while capturing a few assumptions and questions to feed future interations, if necessary
* Generally follow Clean Coding principles - keep it simple, meaningful names, self-explanatory code, YAGNI (You aren't going to need it)
* Prioritize functionality over design for the first iteration

## Assumptions
A list of assumptions made during this exercise are listed below:
* The initial solution was designed for simplicity, so a console application was chosen to demonstrate the core business logic and capabilities.  If this needs to be a more robust solution, we would need to navigate the best target technology and platform.
* The input string is well formed, meaning open/close parentheses are matched and commas are appropriately placed to separate data elements, basic exceptions were added to capture the most simple malformed input.
* Special and non-printable characters were not tested in the input.  We would want to add checks, if these are expected or needed.
* The input string is a literal string and data types or data values are not evaluated.  Adjust the solution if the input string is a represenation of a data set and types or values need to be accommodated.
* The output was selected to print directly to the console to demonstrate the core functionality.  We would want to navigate the best target output if this were to be productionalized.
* The second output defined appeared to be alphabetical for each data group.  If this was coincidental, we'd want to define a format and mechanism for custom sorting.
* For simplicity, the output retains a trailing new line, which was not included in the original instructions.  We would need to trim that from the end if that is not desired.
* The exercise only defined a single data input.  Basic console input was decided to allow for demonstration of malformed or different data sets, if desired.  Remove this functionality if this complicates the solution.
* For simplicity, the solution is very flat and not terribly extendable.  This choice was made intentionally for an initial iteration to not overcomplicate and "boil the ocean" without clarity on additional uses, architecture, or design.
* Basic error handling was added for demonstration purposes.  We would want to determine use and need baesd on expected input/output.
* Internal was chosen for the 2 classes defined.  If this project is extended or used elswhere, this should be re-evaluated.

## Questions
* What is the overall problem that this exercise is inteded to solve?
* Is this intended to be a one-off solution or part of an overall architecture?
* What are the organizational standards around code architecture and design?
* Should this be designed to be cloud-based?  If so, is there an architecture or standard already in place to follow?
* Is user or system interaction desired?
* What input format and interface is desired?  Are there multiple?
* How clean do we expect the input data to be and what exceptions should we account for?
* Is there a deisred output location? If so, are there multiple?
* Are there additional data sets or use cases that need to be accounted for?
* What am I missing?  What have I not thought of or accounted for?

---
# Original Exercise Below
---

# Red Rover Code Puzzle
Thank you for your interest in joining our team.  The following coding exercise helps us get a sense for your approach to turning a requirement into code. If you have any questions please reach out.

## Please do not use AI for this exercise!
We tried to keep this simple enough that it doesn't take a lot of your time, but this is exactly the type of problem that AI can solve in an instant. Please do not consult AI for any part of this exercise.  Thank you for your integrity.

## Instructions
Using the technology of your choice, convert the following string: 

`"(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)"`

To this output: 
```
- id
- name
- email
- type
  - id
  - name
  - customFields
    - c1
    - c2
    - c3
- externalId
``` 

And also to this output:
```
- email
- externalId
- id
- name
- type
  - customFields
    - c1
    - c2
    - c3
  - id
  - name
```

Please send access to the source and a runnable copy of your app. 