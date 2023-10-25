--
-- PostgreSQL database cluster dump
--

-- Started on 2023-09-03 20:24:26

SET default_transaction_read_only = off;

SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;

--
-- Roles
--

CREATE ROLE webapi;
ALTER ROLE webapi WITH NOSUPERUSER NOINHERIT NOCREATEROLE NOCREATEDB LOGIN NOREPLICATION NOBYPASSRLS PASSWORD 'SCRAM-SHA-256$4096:8aaLM3NLXY8gJNkNtTe7RA==$x1GVzprzgHvbs4ShRtkphTNjb8BoHAXRWulpIc5lGQI=:u4YaVdYIS7+/WwdzhlVkWTJsdcgnw1d4Vma9oi48fBw=';


--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4 (Debian 15.4-1.pgdg120+1)
-- Dumped by pg_dump version 15.3

-- Started on 2023-09-03 20:24:26

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

-- Completed on 2023-09-03 20:24:26

--
-- PostgreSQL database dump complete
--

--
-- Database "hotel" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4 (Debian 15.4-1.pgdg120+1)
-- Dumped by pg_dump version 15.3

-- Started on 2023-09-03 20:24:26

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 223 (class 1259 OID 16426)
-- Name: booking; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.booking (
    id integer NOT NULL,
    room_id integer,
    client_id integer,
    booking_date date,
    stay_start_date date,
    stay_end_date date,
    price integer,
    deposit integer
);


--
-- TOC entry 222 (class 1259 OID 16425)
-- Name: booking_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.booking_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3426 (class 0 OID 0)
-- Dependencies: 222
-- Name: booking_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.booking_id_seq OWNED BY public.booking.id;


--
-- TOC entry 221 (class 1259 OID 16419)
-- Name: client; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.client (
    id integer NOT NULL,
    first_name character varying(50),
    last_name character varying(50),
    address character varying(50),
    city character varying(50)
);


--
-- TOC entry 220 (class 1259 OID 16418)
-- Name: client_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.client_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3428 (class 0 OID 0)
-- Dependencies: 220
-- Name: client_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.client_id_seq OWNED BY public.client.id;


--
-- TOC entry 217 (class 1259 OID 16395)
-- Name: hotel; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.hotel (
    id integer NOT NULL,
    station_id integer,
    name character varying(50),
    category integer,
    address character varying(50),
    city character varying(50)
);


--
-- TOC entry 216 (class 1259 OID 16394)
-- Name: hotel_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.hotel_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3430 (class 0 OID 0)
-- Dependencies: 216
-- Name: hotel_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.hotel_id_seq OWNED BY public.hotel.id;


--
-- TOC entry 227 (class 1259 OID 16452)
-- Name: role; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.role (
    id integer NOT NULL,
    name character varying
);


--
-- TOC entry 226 (class 1259 OID 16451)
-- Name: role_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3432 (class 0 OID 0)
-- Dependencies: 226
-- Name: role_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.role_id_seq OWNED BY public.role.id;


--
-- TOC entry 219 (class 1259 OID 16407)
-- Name: room; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.room (
    id integer NOT NULL,
    hotel_id integer,
    number character varying(50),
    capacity integer,
    type integer
);


--
-- TOC entry 218 (class 1259 OID 16406)
-- Name: room_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.room_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3434 (class 0 OID 0)
-- Dependencies: 218
-- Name: room_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.room_id_seq OWNED BY public.room.id;


--
-- TOC entry 215 (class 1259 OID 16386)
-- Name: station; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.station (
    id integer NOT NULL,
    name character varying(50),
    image_name character varying,
    altitude integer
);


--
-- TOC entry 214 (class 1259 OID 16385)
-- Name: station_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.station_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3436 (class 0 OID 0)
-- Dependencies: 214
-- Name: station_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.station_id_seq OWNED BY public.station.id;


--
-- TOC entry 225 (class 1259 OID 16443)
-- Name: user; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."user" (
    id integer NOT NULL,
    name character varying,
    email character varying,
    password character varying
);


--
-- TOC entry 3437 (class 0 OID 0)
-- Dependencies: 225
-- Name: COLUMN "user".password; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public."user".password IS 'Mot de passe hashé.';


--
-- TOC entry 224 (class 1259 OID 16442)
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3439 (class 0 OID 0)
-- Dependencies: 224
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- TOC entry 228 (class 1259 OID 16460)
-- Name: user_role; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.user_role (
    user_id integer,
    role_id integer
);


--
-- TOC entry 3237 (class 2604 OID 16429)
-- Name: booking id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.booking ALTER COLUMN id SET DEFAULT nextval('public.booking_id_seq'::regclass);


--
-- TOC entry 3236 (class 2604 OID 16422)
-- Name: client id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.client ALTER COLUMN id SET DEFAULT nextval('public.client_id_seq'::regclass);


--
-- TOC entry 3234 (class 2604 OID 16398)
-- Name: hotel id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.hotel ALTER COLUMN id SET DEFAULT nextval('public.hotel_id_seq'::regclass);


--
-- TOC entry 3239 (class 2604 OID 16455)
-- Name: role id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.role ALTER COLUMN id SET DEFAULT nextval('public.role_id_seq'::regclass);


--
-- TOC entry 3235 (class 2604 OID 16410)
-- Name: room id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.room ALTER COLUMN id SET DEFAULT nextval('public.room_id_seq'::regclass);


--
-- TOC entry 3233 (class 2604 OID 16389)
-- Name: station id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.station ALTER COLUMN id SET DEFAULT nextval('public.station_id_seq'::regclass);


--
-- TOC entry 3238 (class 2604 OID 16446)
-- Name: user id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- TOC entry 3413 (class 0 OID 16426)
-- Dependencies: 223
-- Data for Name: booking; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.booking (id, room_id, client_id, booking_date, stay_start_date, stay_end_date, price, deposit) FROM stdin;
1	1	1	2022-01-10	2022-07-01	2022-07-15	2400	800
2	2	2	2022-01-10	2022-07-01	2022-07-15	3400	100
3	1	3	2022-01-10	2022-07-01	2022-07-15	400	50
4	2	4	2022-01-10	2022-07-01	2022-07-15	7200	1800
5	3	5	2022-01-10	2022-07-01	2022-07-15	1400	450
6	4	6	2022-01-10	2022-07-01	2022-07-15	2400	780
7	4	6	2022-01-10	2022-07-01	2022-07-15	500	80
8	4	1	2022-01-10	2022-07-01	2022-07-15	40	0
\.


--
-- TOC entry 3411 (class 0 OID 16419)
-- Dependencies: 221
-- Data for Name: client; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.client (id, first_name, last_name, address, city) FROM stdin;
1	John	Doe		LA
2	Josh	Homme		Palm Desert
3	Weller	Paul		Londres
4	Jack	White		Detroit
5	Les	Claypool		San Francisco
6	Chris	Squire		Londres
7	Ronnie	Wood		Londres
\.


--
-- TOC entry 3407 (class 0 OID 16395)
-- Dependencies: 217
-- Data for Name: hotel; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.hotel (id, station_id, name, category, address, city) FROM stdin;
1	1	Le Magnifique	3	rue du bas	Pralo
2	1	Hotel du haut	1	rue du haut	Pralo
3	2	Le Narval	3	place de la liberation	Vonten
4	2	Les Pissenlis	4	place du 14 juillet	Bretou
5	2	RR Hotel	5	place du bas	Bretou
6	2	La Brique	2	place du haut	Bretou
7	3	Le Beau Rivage	3	place du centre	Toras
\.


--
-- TOC entry 3417 (class 0 OID 16452)
-- Dependencies: 227
-- Data for Name: role; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.role (id, name) FROM stdin;
1	ROLE_ADMIN
2	ROLE_USER
\.


--
-- TOC entry 3409 (class 0 OID 16407)
-- Dependencies: 219
-- Data for Name: room; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.room (id, hotel_id, number, capacity, type) FROM stdin;
1	1	001	2	1
2	1	002	3	1
3	1	003	2	1
4	1	101	1	1
5	1	102	2	1
6	1	103	3	1
7	1	201	2	1
8	1	202	7	1
9	1	203	1	1
10	2	001	2	1
11	2	002	2	1
12	2	003	1	1
13	2	101	2	1
14	2	102	1	1
15	2	103	3	1
16	2	201	2	1
17	2	202	4	1
18	2	203	4	1
19	3	001	3	1
20	3	002	1	1
21	3	003	2	1
22	3	101	2	1
23	3	102	2	1
24	3	103	2	1
25	3	201	2	1
26	3	202	4	1
27	3	203	4	1
28	4	001	4	1
29	4	002	2	1
30	4	003	4	1
31	4	101	1	1
32	4	102	2	1
33	4	103	2	1
34	4	201	2	1
35	4	202	2	1
36	4	203	3	1
37	5	001	3	1
38	5	002	2	1
39	5	003	2	1
40	5	101	1	1
41	5	102	4	1
42	5	103	1	1
43	5	201	2	1
44	5	202	4	1
45	5	203	4	1
46	6	001	1	1
47	6	002	1	1
48	6	003	1	1
49	6	101	1	1
50	6	102	1	1
51	6	103	1	1
52	6	201	1	1
53	6	202	1	1
54	6	203	1	1
55	7	001	1	1
56	7	002	5	1
57	7	003	5	1
58	7	101	5	1
59	7	102	5	1
60	7	103	5	1
61	7	201	5	1
62	7	202	5	1
63	7	203	5	1
\.


--
-- TOC entry 3405 (class 0 OID 16386)
-- Dependencies: 215
-- Data for Name: station; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.station (id, name, image_name, altitude) FROM stdin;
1	La Montagne	\N	2500
2	Le Sud	\N	200
3	La Plage	\N	10
\.


--
-- TOC entry 3415 (class 0 OID 16443)
-- Dependencies: 225
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."user" (id, name, email, password) FROM stdin;
2	user	user@user.fr	beec103505fc0c4bff620b8f859784fffcc48b167017bc7fcafbf1dc6930b4a73cd56246a5587bdca8751263588f6050
1	admin	admin@admin.fr	6644675bc05cabdeba410344d80debe6aea307237668f5887ad56c89ab3e2e871a7366c8a32f861c97445f8c4bb4d563
8	lambda	lambda@lambda.fr	af4785eeacd555fe7b410cb4e10e7decd6227d5e1b8497587686b7201f49b82e8782cadb2f982ccc5be36b52fb5509e9
\.


--
-- TOC entry 3418 (class 0 OID 16460)
-- Dependencies: 228
-- Data for Name: user_role; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.user_role (user_id, role_id) FROM stdin;
1	1
2	2
8	2
\.


--
-- TOC entry 3442 (class 0 OID 0)
-- Dependencies: 222
-- Name: booking_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.booking_id_seq', 8, true);


--
-- TOC entry 3443 (class 0 OID 0)
-- Dependencies: 220
-- Name: client_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.client_id_seq', 7, true);


--
-- TOC entry 3444 (class 0 OID 0)
-- Dependencies: 216
-- Name: hotel_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.hotel_id_seq', 1, false);


--
-- TOC entry 3445 (class 0 OID 0)
-- Dependencies: 226
-- Name: role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.role_id_seq', 2, true);


--
-- TOC entry 3446 (class 0 OID 0)
-- Dependencies: 218
-- Name: room_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.room_id_seq', 63, true);


--
-- TOC entry 3447 (class 0 OID 0)
-- Dependencies: 214
-- Name: station_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.station_id_seq', 1, false);


--
-- TOC entry 3448 (class 0 OID 0)
-- Dependencies: 224
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.user_id_seq', 8, true);


--
-- TOC entry 3249 (class 2606 OID 16431)
-- Name: booking booking_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.booking
    ADD CONSTRAINT booking_pkey PRIMARY KEY (id);


--
-- TOC entry 3247 (class 2606 OID 16424)
-- Name: client client_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_pkey PRIMARY KEY (id);


--
-- TOC entry 3243 (class 2606 OID 16400)
-- Name: hotel hotel_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.hotel
    ADD CONSTRAINT hotel_pkey PRIMARY KEY (id);


--
-- TOC entry 3255 (class 2606 OID 16459)
-- Name: role role_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_pk PRIMARY KEY (id);


--
-- TOC entry 3245 (class 2606 OID 16412)
-- Name: room room_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT room_pkey PRIMARY KEY (id);


--
-- TOC entry 3241 (class 2606 OID 16393)
-- Name: station station_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.station
    ADD CONSTRAINT station_pkey PRIMARY KEY (id);


--
-- TOC entry 3251 (class 2606 OID 16450)
-- Name: user user_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (id);


--
-- TOC entry 3253 (class 2606 OID 16484)
-- Name: user user_un; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_un UNIQUE (name);


--
-- TOC entry 3258 (class 2606 OID 16437)
-- Name: booking booking_client_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.booking
    ADD CONSTRAINT booking_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.client(id);


--
-- TOC entry 3259 (class 2606 OID 16432)
-- Name: booking booking_room_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.booking
    ADD CONSTRAINT booking_room_id_fkey FOREIGN KEY (room_id) REFERENCES public.room(id);


--
-- TOC entry 3256 (class 2606 OID 16401)
-- Name: hotel hotel_station_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.hotel
    ADD CONSTRAINT hotel_station_id_fkey FOREIGN KEY (station_id) REFERENCES public.station(id);


--
-- TOC entry 3257 (class 2606 OID 16413)
-- Name: room room_hotel_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT room_hotel_id_fkey FOREIGN KEY (hotel_id) REFERENCES public.hotel(id);


--
-- TOC entry 3260 (class 2606 OID 16468)
-- Name: user_role user_role_role_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.user_role
    ADD CONSTRAINT user_role_role_id_fkey FOREIGN KEY (role_id) REFERENCES public.role(id);


--
-- TOC entry 3261 (class 2606 OID 16478)
-- Name: user_role user_role_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.user_role
    ADD CONSTRAINT user_role_user_id_fkey FOREIGN KEY (user_id) REFERENCES public."user"(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3425 (class 0 OID 0)
-- Dependencies: 223
-- Name: TABLE booking; Type: ACL; Schema: public; Owner: -
--

GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE public.booking TO webapi;


--
-- TOC entry 3427 (class 0 OID 0)
-- Dependencies: 221
-- Name: TABLE client; Type: ACL; Schema: public; Owner: -
--

GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE public.client TO webapi;


--
-- TOC entry 3429 (class 0 OID 0)
-- Dependencies: 217
-- Name: TABLE hotel; Type: ACL; Schema: public; Owner: -
--

GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE public.hotel TO webapi;


--
-- TOC entry 3431 (class 0 OID 0)
-- Dependencies: 227
-- Name: TABLE role; Type: ACL; Schema: public; Owner: -
--

GRANT SELECT ON TABLE public.role TO webapi;


--
-- TOC entry 3433 (class 0 OID 0)
-- Dependencies: 219
-- Name: TABLE room; Type: ACL; Schema: public; Owner: -
--

GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE public.room TO webapi;


--
-- TOC entry 3435 (class 0 OID 0)
-- Dependencies: 215
-- Name: TABLE station; Type: ACL; Schema: public; Owner: -
--

GRANT SELECT,INSERT,DELETE,TRIGGER,UPDATE ON TABLE public.station TO webapi;


--
-- TOC entry 3438 (class 0 OID 0)
-- Dependencies: 225
-- Name: TABLE "user"; Type: ACL; Schema: public; Owner: -
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public."user" TO webapi;


--
-- TOC entry 3440 (class 0 OID 0)
-- Dependencies: 224
-- Name: SEQUENCE user_id_seq; Type: ACL; Schema: public; Owner: -
--

GRANT USAGE ON SEQUENCE public.user_id_seq TO webapi;


--
-- TOC entry 3441 (class 0 OID 0)
-- Dependencies: 228
-- Name: TABLE user_role; Type: ACL; Schema: public; Owner: -
--

GRANT SELECT,INSERT,UPDATE ON TABLE public.user_role TO webapi;


-- Completed on 2023-09-03 20:24:26

--
-- PostgreSQL database dump complete
--

-- Completed on 2023-09-03 20:24:27

--
-- PostgreSQL database cluster dump complete
--

