import React from 'react';
import { motion } from 'framer-motion';

interface FloatingShapeProps {
  color: string;
  width: string;
  height: string;
  top: string;
  left: string;
  delay: number;
}

const FloatingShape: React.FC<FloatingShapeProps> = ({
  color,
  width,
  height,
  top,
  left,
  delay
}) => {
  return (
    <>
      <motion.div
        className='position-absolute rounded-circle opacity-20 blur-xl'
        style={{
          backgroundColor: color,
          width: width,
          height: height,
          top: top,
          left: left,
          zIndex: 1
        }}
        animate={{ y: ['0', '100%', '0'], x: ['0%', '100%', '0%'], rotate: [0, 360] }}
        transition={{
          duration: 20,
          ease: 'linear',
          repeat: Infinity,
          delay: delay
        }}
        aria-hidden='true'
      ></motion.div>
    </>
  );
};

export default FloatingShape;
