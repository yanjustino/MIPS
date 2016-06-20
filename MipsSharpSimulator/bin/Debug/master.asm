	    .data
MatrizA:.word 1,2,3,4,5,6, 7,8,9,10,11,12, 13,14,15,16,17,18, 19,20,21,22,23,24, 25,26,27,28,29,30, 31,32,33,34,35,36
MatrizB:.word 2,2,2,2,2,2, 2,2,2,2,2,2, 2,2,2,2,2,2, 2,2,2,2,2,2, 2,2,2,2,2,2, 2,2,2,2,2,2
MatrizC:.word 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0, 0,0,0,0,0,0
Aux:.word 0,0,0,0,0,0
	    .text
	    .globl main
	
main:	
        li $s0, 0
        li $s1, 6
	    li $s2, 0
        la $t0, MatrizA
        la $t1, MatrizB
        la $t2, MatrizC
        la $t3, Aux

enviaA: snd $s0, 24, $t0
        addi $s0, $s0, 1
        bne $s0, $s1, enviaA
	    li $s0, 0

enviaB: snd $s0, 144, $t1
        addi $s0, $s0, 1
        bne $s0, $s1, enviaB

recebeC: rcv $s3, 24, $t3
         li $a0, 0
         li $a1, 5
         addi $s3, $s3, 1
         mult $a2, $t2, $s3

copia: lw $a3, 0($t3)
       sw $a3, 0($a2)
       addi $t3, $t3, 4
       addi $a2, $a2, 4
       addi $a0, $a0, 1
       bne $a0, $a1, copia
       addi $s2, $s2, 1
       bne $s2, $s1, recebeC