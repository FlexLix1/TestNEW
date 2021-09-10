using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignments1 : ProcessingLite.GP21

{
   

    // Update is called once per frame
    void Update()
    {
        LetterF();
        LetterU();
        LetterR();
        LetterK();
        LetterA();
        LetterN();

        }

        void LetterF()
        {
            Line(1, 1, 1, 6);
            Line(1, 6, 3, 6);
            Line(1, 4, 2.5f, 4);
        }

         void LetterU()
        {
            Line(3, 1, 3, 3);
            Line(3, 1, 5, 1);
            Line(5, 1, 5, 3);
        }

         void LetterR()
        {
            Line(6, 1, 6, 3);
            Line(6, 3, 7, 3);
        }

         void LetterK()
        {
            Line(8, 1, 8, 4);
            Line(8, 2.5f, 9, 4);
            Line(8, 2.5f, 9, 1);
        }

         void LetterA()
        {
            Line(10, 1, 10, 3);
            Line(10, 3, 11, 3);
            Line(10, 2, 11, 2);
            Line(11, 1, 11, 3);
        }

         void LetterN()
        {

            Line(12, 1, 12, 3);
            Line(12, 3, 13, 3);
            Line(13, 1, 13, 3);
        
        }
    
}
