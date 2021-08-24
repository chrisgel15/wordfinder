# WordFinder
## Program.cs
It is the entry point to execute the program. 

It creates a random matrix of a configurable size and also configures the words to select in the matrix.

## WordFinder.cs
It is the service class that delegates logic to the model (WordMatrix.cs).

I chose this approach to leave the service as clean as possible, add more entities to ease the understanding of the logic and to encapsulate the data model.

I did not change the interface as requested but I added a private field and two private minor methods. I added a business validation to validate the matrix is a perfect square, but this could be removed and perform some internal checks if needed.

## WordMatrix.cs
The way I decided to implement this is to create a data model representation that contains both the columns and the rows of the matrix. I understand I am doubling the data structure size here, but I am simplifying the word search by doing this. Also, the mental representation of the columns and the rows is also easier to understand for humans and avoid more complex algorithms. I always try to go for the easier approach and then refactor and aim for better performance after deep analysis.

In this way, the logic is quite simple:
- It creates the columns structure (FillColums method).
- It creates the rows structure (FillRows method).
- It iterates to find the count for each word (FindTopTenResults method).
- It filters, orders, and select the results (GetTopTenFoundWords method).

# Additional Notes
I removed code comments so the code is cleaner to read, I don't like commenting code anyways (prefer cleaner code + documentation).
I did not add unit test but they are simple as well, as the code is decoupled and some logic is trivial due to its design.

Additional performance optimizations could come into:
- Designing a different data model or operating in a more complex algorithm directly into the IEnumerable collection.
- Avoid using "foreach" statement, change to "for" whenever possible.
- Removing the LINQ queries would improve performance when selecting hundreds or thousands of words.
- Finally, an asynchronous approach where I could find by columns and rows simultaneously could impact the performance significantly as well.
