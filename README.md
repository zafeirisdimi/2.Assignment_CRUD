---------------------------------------------------------

![ProjectLogo](Assignment2/img/ProjectLogo_assignment2.png)

-----------------------------------------------------

# Assignment2_CRUD

You  are  required  to  produce  a  solution  that  implements a <strong>CRUD</strong> using <strong>MVC</strong> methodologies for the entity <strong>Trainers</strong>.

<details><summary><h2>Tasks</h2></summary>
<p><h3>You    need    to    submit    all    the    produced    files    in    a    zip    file    named    by your_name_individual_partb.zip</h3>
<ul>
    <li> <h3>Create Trainer [20marks]</h3> </li>
    <li> <h3>Read Trainer details [20marks] </h3> </li>
    <li> <h3>Update Trainer details [20marks]</h3></li>
    <li> <h3>Delete Trainer [20marks] </h3></li>
    <li> <h3>Use of MVC technologies [20marks]</h3></li>
  </ul>
</p>
</details>


------------------------------------------------------------------------------------------------------------------------------------------------------


📋Table of contents
=================

<!--ts-->


- [Assignment2_CRUD](#assignment2_crud)
 - [ApplicationDatabase](#applicationdatabase)
    - [ApplicationContext](#applicationcontext)
 - [Migrations](#migrations)
    - [Configurations](#configurations)
 - [Models](#models)
    - [Assignment](#assignment)
    - [Course](#course)
    - [Trainer](#trainer)
    - [Student](#student)
 - [Interfaces](#interfaces)
    - [IPerson](#iperson)
 - [Repositories](#repositories)
    - [AssignmentRepository](#assignmentrepository)
    - [CourseRepository](#trainerrepository)
    - [TrainerRepository](#trainerrepository)
    - [StudentRepository](#studentrepository)
 - [Views](#views)
  - [TrainerView](#trainerview)
     - [Create](#create)
     - [Read](#read)
     - [Edit](#edit)
     - [Delete](#delete)
  - [CourseView](#courseview)
     - [Create](#create)
     - [Read](#read)
     - [Edit](#edit)
     - [Delete](#delete)
  - [StudentView](#studentview)
     - [Create](#create)
     - [Read](#read)
     - [Edit](#edit)
     - [Delete](#delete)
  - [AssignmentView](#assignmentview)
     - [Create](#create)
     - [Read](#read)
     - [Edit](#edit)
     - [Delete](#delete)
 - [Controllers](#controllers)
 - [Installation](#installation)
 - [Technologies and Tools](#technologies-and-tools)
        

  
<!--te-->

------------------------------------------------------------------------------------------------------------------------------------------------------


## ApplicationDatabase ##

### ApplicationContext ###

----------------------------------------------------------------------------------------------------------

## Migrations ##

### Configurations ###

----------------------------------------------------------------------------------------------------------

## Model ##

### Trainer ###
	
| Type           | Properties       | Methods | Required | Min| Max | 
| :---:          |     :---:        |  :---:  |  :---:  | :---: | :---: | 
| int            | ID     | get, set   | ☑️ | 1 | no-limit | 
| string            | FirstName     | get, set   |☑️ | 10 | 50 |
| string         | LastName      | get, set    |☑️| 10 | 50 |
| string         | PhoneNumber       | get, set    |☑️| 10 | 20 |
| int         | Salary       | get, set    |☑️| 1000 | 3000 |


#### Validation Error Messages ####

| ErrorMessageCode         | ErrorMessage       | 
| :---:          |     :---:        | 
| int            | ID     | 
| string            | FirstName     | 
| string         | LastName      |
| string         | PhoneNumber       | 
| int         | Salary       | 

##### [🔙🏠](#assignment2_crud) #####

### Student ###

| Type           | Properties       | Methods | Required | Min| Max | 
| :---:          |     :---:        |  :---:  |  :---:  | :---: | :---: | 
| int            | ID     | get, set   | ☑️ | 1 | no-limit | 
| string            | FirstName     | get, set   |☑️ | 10 | 50 |
| string         | LastName      | get, set    |☑️| 10 | 50 |
| string         | PhoneNumber       | get, set    |☑️| 10 | 20 |
| int         | Salary       | get, set    |☑️| 1000 | 3000 |

#### Validation Error Messages ####

| ErrorMessageCode         | ErrorMessage       | 
| :---:          |     :---:        | 
| int            | ID     | 
| string            | FirstName     | 
| string         | LastName      |
| string         | PhoneNumber       | 
| int         | Salary       | 


### Course ###

| Type           | Properties       | Methods | Required | Min| Max | 
| :---:          |     :---:        |  :---:  |  :---:  | :---: | :---: | 
| int            | ID     | get, set   | ☑️ | 1 | no-limit | 
| string            | Title     | get, set   |☑️ | 10 | 50 |
| string            | Description     | get, set   |☑️ | 10 | 50 |
| int         | Duration      | get, set    |☑️| 10 | 50 |
| DateTime         | StarDate      | get, set    |☑️| 10 | 50 |
| string         | Catergory       | get, set    |☑️| 10 | 20 |
| List Trainer | Trainers | get,set | ☑️ | 1 | no-limit

#### Validation Error Messages ####

| ErrorMessageCode         | ErrorMessage       | 
| :---:          |     :---:        | 
| int            | ID     | 
| string            | FirstName     | 
| string         | LastName      |
| string         | PhoneNumber       | 
| int         | Salary       | 


##### [🔙🏠](#assignment2_crud) #####

### Assignment ###

| Type           | Properties       | Methods | Required | Min| Max | 
| :---:          |     :---:        |  :---:  |  :---:  | :---: | :---: | 
| int            | ID     | get, set   | ☑️ | 1 | no-limit | 
| string            | FirstName     | get, set   |☑️ | 10 | 50 |
| string         | LastName      | get, set    |☑️| 10 | 50 |
| string         | PhoneNumber       | get, set    |☑️| 10 | 20 |
| int         | Salary       | get, set    |☑️| 1000 | 3000 |

#### Validation Error Messages ####

| ErrorMessageCode         | ErrorMessage       | 
| :---:          |     :---:        | 
| int            | ID     | 
| string            | FirstName     | 
| string         | LastName      |
| string         | PhoneNumber       | 
| int         | Salary       | 

##### [🔙🏠](#assignment2_crud) #####
-------------------------------------------------------------------------------------------------------------------

## Interfaces ##
### IPerson ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |
| string         | PhoneNumber       | get, set    |
| int         | Salary       | get, set    |

-------------------------------------------------------------------------------------------------------------------

## Repository ##
### TrainerRepository ###

| Method           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |
| string         | PhoneNumber       | get, set    |
| int         | Salary       | get, set    |

### StudentRepository ###

| Method           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |
| string         | PhoneNumber       | get, set    |
| int         | Salary       | get, set    |

### CourseRepository ###

| Method           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |
| string         | PhoneNumber       | get, set    |
| int         | Salary       | get, set    |

### AssignmentRepository ###

| Method           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |
| string         | PhoneNumber       | get, set    |
| int         | Salary       | get, set    |

##### [🔙🏠](#assignment2_crud) #####
------------------------------------------------------------------------------------------------------------------
## Views ##
## TrainerView ##

#### Methods ####

| Title         | PARAMETER       |  GOAL |
| :---:          |     :---:        | :---: |
| GetAll            | ID     | 
| GetAllWithStudent            | FirstName     | 
| GetAllWithStudentAndCourses         | LastName      |
| GetById         | PhoneNumber       | 
| Create        | Salary       | 
| Edit            | ID     | 
| Delete           | FirstName     | 
| GetAllWithStudentAndCourses         | LastName      |
| GetCourses         | PhoneNumber       | 
| GetStudents        | Salary       | 

### Create ###
-
------------------------------------------------------------------------------------------------------------------
### Read ###
-

##### [Back to >Top<](#assignment2_crud) #####
------------------------------------------------------------------------------------------------------------------
### Edit ###
-
------------------------------------------------------------------------------------------------------------------
### Delete ###

## StudentView ##

#### Methods ####

| Title         | PARAMETER       |  GOAL |
| :---:          |     :---:        | :---: |
| GetAll            | ID     | 
| GetAllWithStudent            | FirstName     | 
| GetAllWithStudentAndCourses         | LastName      |
| GetById         | PhoneNumber       | 
| Create        | Salary       | 
| Edit            | ID     | 
| Delete           | FirstName     | 
| GetAllWithStudentAndCourses         | LastName      |
| GetCourses         | PhoneNumber       | 
| GetStudents        | Salary       | 

### Create ###
### Read ###
### Edit ###

##### [🔙🏠](#assignment2_crud) #####

## CourseView ##

#### Methods ####

| Title         | PARAMETER       |  GOAL |
| :---:          |     :---:        | :---: |
| GetAll            | ID     | 
| GetAllWithStudent            | FirstName     | 
| GetAllWithStudentAndCourses         | LastName      |
| GetById         | PhoneNumber       | 
| Create        | Salary       | 
| Edit            | ID     | 
| Delete           | FirstName     | 
| GetAllWithStudentAndCourses         | LastName      |
| GetCourses         | PhoneNumber       | 
| GetStudents        | Salary       | 

### Create ###
-
------------------------------------------------------------------------------------------------------------------
### Read ###
-

##### [🔙🏠](#assignment2_crud) #####

------------------------------------------------------------------------------------------------------------------
### Edit ###
-

## AssignmentView ##

#### Methods ####

| Title         | PARAMETER       |  GOAL |
| :---:          |     :---:        | :---: |
| GetAll            | ID     | 
| GetAllWithStudent            | FirstName     | 
| GetAllWithStudentAndCourses         | LastName      |
| GetById         | PhoneNumber       | 
| Create        | Salary       | 
| Edit            | ID     | 
| Delete           | FirstName     | 
| GetAllWithStudentAndCourses         | LastName      |
| GetCourses         | PhoneNumber       | 
| GetStudents        | Salary       | 

### Create ###
### Read ###
### Edit ###
### Delete ###

##### [🔙🏠](#assignment2_crud) #####

------------------------------------------------------------------------------------------------------------------
## Controller ##
### TrainerController ###

| Method           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Action            | ID     | get, set   |
| Action            | FirstName     | get, set   |
| Action         | LastName      | get, set    |
| Action         | PhoneNumber       | get, set    |
| Action         | Salary       | get, set    |

### StudentController ###

| Method           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Action            | ID     | get, set   |
| Action            | FirstName     | get, set   |
| Action         | LastName      | get, set    |
| Action         | PhoneNumber       | get, set    |
| Action         | Salary       | get, set    |

### CourseController ###

| Method           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Action            | ID     | get, set   |
| Action            | FirstName     | get, set   |
| Action         | LastName      | get, set    |
| Action         | PhoneNumber       | get, set    |
| Action         | Salary       | get, set    |

### AssignmentController ###

| Method           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Action            | ID     | get, set   |
| Action            | FirstName     | get, set   |
| Action         | LastName      | get, set    |
| Action         | PhoneNumber       | get, set    |
| Action         | Salary       | get, set    |

## Installation ##


## Technologies and Tools ##

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Entity Framework](https://docs.microsoft.com/en-us/ef/ef6/)
- [ASP.NET MVC Pattern](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc))
- [Visual Studio Community Edition](https://visualstudio.microsoft.com/vs/community/)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [HTML](https://www.w3schools.com/html/)
- [CSS](https://www.w3schools.com/css/)
- [Bootstrap 4](https://getbootstrap.com/)
- [Font Awesome](https://fontawesome.com/)

##### [🔙🏠](#assignment2_crud) #####
