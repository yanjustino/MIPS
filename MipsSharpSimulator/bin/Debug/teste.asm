	.data
	
MatrizA:.word 1,2,3,4,5,6, 7,8,9,10,11,12, 13,14,15,16,17,18, 19,20,21,22,23,24, 25,26,27,28,29,30, 31,32,33,34,35,36
MatrizB:.word 2,2,2,2,2,2, 2,2,2,2,2,2, 2,2,2,2,2,2, 2,2,2,2,2,2, 2,2,2,2,2,2, 2,2,2,2,2,2
MatrizC:.word 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0
Aux:    .word 0,0,0,0,0,0
	.text
	.globl main
	
main:	
        li $s0, 0
        li $s1, 6
	    li $s2, 2
        la $t0, MatrizA
        la $t1, MatrizB
        la $t2, MatrizC        
        la $t3, Aux          
                        
enviaA: addi $s0, $s0, 2
        addi $s0, $s0, 1
        bne $s0, $s1, enviaA
        li $s0, 1

enviaB: addi $s2, $s2, 2
        bqe $s2, 2, enviaB

enviaC: snd $s0, 24, $t0  
          
enviaD: rcv $s0, 24, $t3  